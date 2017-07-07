using TruliaMapsGoogleAPIParser.Components;
using TruliaMapsGoogleAPIParser.DataProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TruliaMapsGoogleAPIParser
{
    public class AddressParser
    {
        WebProxy proxy;
        public AddressParser()
        {
           //proxy = ProxySolver.Instance.getNewProxy();
        }
        #region Методы для получения данных местоположения через Google Maps Geocoding API
        /// <summary>
        /// Получает результат GET-запроса в виде JSON от Google Maps Geocoding 
        /// </summary>
        /// <param name="addressOrLatlng">адрес или координаты через запятую. Пример: "29.739600,-95.446000"</param>
        /// <param name="type">Тип геокодирования(по адресу или по координатам)</param>
        /// <param name="apikey">Ключ для работы с API от Google, выделенный под конкретный проект</param>
        /// <returns>Возвращает массив объектов c результатами мест в JSON </returns>
        public static string GetJsonMapResponse(string addressOrLatlng, Constants.TypeOfMapGrabbing type, string apiKey = "")
        {
            string GETRequestLink = type == Constants.TypeOfMapGrabbing.ByAddress ? Constants.GoogleRequestParams.AddressMapsQueryPattern + addressOrLatlng.Replace(" ", "+") :
                Constants.GoogleRequestParams.LatlngMapsQueryPattern + addressOrLatlng; //в адресе заменяем пробелы на плюсы для соответствия формату запроса + исходя из типа, задаем правильный текст запроса
            if (apiKey != "")
            {
                GETRequestLink += "&key=" + apiKey;
            }
            return WebHelpers.GetWebResponceContent(GETRequestLink);
        }

        public static string GetJsonMapResponseThrowProxy(string addressOrLatlng, Constants.TypeOfMapGrabbing type, string apiKey = "")
        {
            string GETRequestLink = type == Constants.TypeOfMapGrabbing.ByAddress ? Constants.GoogleRequestParams.AddressMapsQueryPattern + addressOrLatlng.Replace(" ", "+") :
                Constants.GoogleRequestParams.LatlngMapsQueryPattern + addressOrLatlng; //в адресе заменяем пробелы на плюсы для соответствия формату запроса + исходя из типа, задаем правильный текст запроса
            if (apiKey != "")
            {
                GETRequestLink += "&key=" + apiKey;
            }
            return WebHelpers.GetWebResponceContentThrowProxy(GETRequestLink, ProxySolver.Instance.getNewProxy());
        }

        #endregion

        #region Методы для обработки исходной таблицы Offers БД Trulia

        public List<AddressInfo> GetAddressesByRange(long start, long end)
        {
            DataTable TruliaAddressesDataTable = DataProvider.Instance.GetDataset(start, end).Tables[0];
            //DataProvider.ConsoleView(TruliaAddressesDataTable); //выводим на консоль
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Convert.ToInt32(Resources.MaxDegreeOfParallelism);

            List<AddressInfo> addresses = new List<AddressInfo>();
            //Parallel.For(0, TruliaAddressesDataTable.Rows.Count, options, (cur) =>
            for(int i = 0; i < TruliaAddressesDataTable.Rows.Count; i++)
            {
                addresses.Add(new AddressInfo(TruliaAddressesDataTable.Rows[i]));
            }
            return addresses;
        }
        #endregion


        public void StartGrabbing()
        {
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Convert.ToInt32(Resources.MaxDegreeOfParallelism);
            long TruliaCount = DataProviders.DataProvider.Instance.GetCount(); //смотрим, сколько записей в таблице
            Console.WriteLine(TruliaCount);
            int range = 10000;
            for (int i = 1; i <= TruliaCount; i += range)
            {
                if ((i - 1) % 1000 == 0)
                {
                    Console.WriteLine("Now {0} cells", i - 1);
                }
                List<AddressInfo> adresses;
                if (i + range > TruliaCount)
                {
                    adresses = GetAddressesByRange(i, TruliaCount);
                }
                else
                {
                    adresses = GetAddressesByRange(i, i + range - 1);
                }
                Parallel.ForEach(adresses, options, address =>
                {
                    //for (int j = 0;j < adresses.Count;j++)

                    Console.WriteLine(address.PlaceName);
                    address.ParseJSON();
                    if (address.JSON != Constants.WebAttrsNames.NotFound)
                    {
                        if (AddressParser.ReadJsonToObject(address.JSON).status == Constants.GoogleMapsGeocodingStatusCodes.OVER_QUERY_LIMIT)
                        {
                            return;
                        }
                    }
                    address.InsertIntoDb();
                });
                //Parallel.ForEach(adresses,options, address => {
                //    address.ParseJSON();
                //    address.InsertIntoDb();
                //});
                    
            }           

        }

        public List<AddressInfo> GetJSONPlacesFromDb(long start, long end)
        {
            DataTable TruliaAddressesDataTable = DataProvider.Instance.GetDatasetFromTruliaPlaces(start, end).Tables[0];
            //DataProvider.ConsoleView(TruliaAddressesDataTable); //выводим на консоль
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Convert.ToInt32(Resources.MaxDegreeOfParallelism);

            List<AddressInfo> addresses = new List<AddressInfo>();
            //Parallel.For(0, TruliaAddressesDataTable.Rows.Count, options, (cur) =>
            for (int i = 0; i < TruliaAddressesDataTable.Rows.Count; i++)
            {
                addresses.Add(new AddressInfo(TruliaAddressesDataTable.Rows[i]));
            }
            return addresses;
        }

        public static GeocodeJsonObject ReadJsonToObject(string json)
        {
            GeocodeJsonObject deserializedObject = new GeocodeJsonObject();
            //MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedUser.GetType());
            //deserializedUser = ser.ReadObject(ms) as User;
            //ms.Close();
                
            deserializedObject = JsonConvert.DeserializeObject<GeocodeJsonObject>(json);
            return deserializedObject;
        }
        /// <summary>
        /// Берет строки из таблицы, парсит JSON и раскидывает по столбцам 
        /// </summary>
        public void ConvertJsonStringFromDbToCells()
        {
            long TruliaCount = DataProviders.DataProvider.Instance.GetPlacesCount(); //смотрим, сколько записей в таблице
            Console.WriteLine(TruliaCount);
            int range = 10000;
            for (int i = 0; i <= TruliaCount; i += range)
            {

                if ((i) % 1000 == 0)
                {
                    Console.WriteLine("Now {0} cells", i);
                }
                List<AddressInfo> adresses;
                Console.WriteLine("Getting next part...");
                if (i + range > TruliaCount)
                {
                    adresses = GetJSONPlacesFromDb(i, TruliaCount);
                }
                else
                {
                    adresses = GetJSONPlacesFromDb(i, i + range - 1);
                }
                ParallelOptions options = new ParallelOptions();
                options.MaxDegreeOfParallelism = Convert.ToInt32(Resources.MaxDegreeOfParallelism);
                Parallel.ForEach(adresses, options, address =>
                {
                    //Console.WriteLine(adresses[j].PlaceLink);
                    if (address.JSON != String.Empty && address.JSON != Constants.WebAttrsNames.NotFound)
                    {
                        GeocodeJsonObject o = ReadJsonToObject(address.JSON);
                        RooftopResultPlace res = new RooftopResultPlace(o, address.ID);

                        res.InsertToDb();
                    }
                    else
                    {
                        Console.WriteLine("Запись с номером ID={0} не содержит JSON", address.ID);
                    }
                });



            }
        }

    }
}
