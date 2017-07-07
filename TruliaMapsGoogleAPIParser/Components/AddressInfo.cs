using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruliaMapsGoogleAPIParser.Components
{
    /// <summary>
    /// Описывает структуру строки, получаемой из исходной таблицы OffersTable для БД Trulia
    /// </summary>
    public class AddressInfo
    {
        

        public long ID { get; set; } = -1;
        public string PlaceName { get; set; } = Constants.TruliaDbAddressNulls.NoPlaceName;
        public string JSON { get; protected set; } = String.Empty;
        public AddressInfo(long id, string placeName, string placeLink)
        {
            ID = id;
            PlaceName = placeName;

        }

        public AddressInfo(DataRow dataRow)
        {
            ID = Convert.ToInt64(dataRow[0]);
            PlaceName = dataRow[1].ToString();
        }

        public override string ToString()
        {
            return String.Format("ID: {0}, PlaceName: {1}", ID, PlaceName);
        }
        public void InsertIntoDb()
        {
            SqlCommand insertAddress = DataProviders.DataProvider.Instance.CreateSQLCommandForSP(Resources.SP_InsertPlaceInfo, Resources.DbTruliaConnectionString);
            insertAddress.Parameters.AddWithValue("@ID", ID);
            insertAddress.Parameters.AddWithValue("@Address", ((object)PlaceName) ?? (DBNull.Value));
            insertAddress.Parameters.AddWithValue("@JSON", ((object)JSON) ?? (DBNull.Value));
            DataProviders.DataProvider.Instance.ExecureSP(insertAddress);
        }
        public string ParseJSON()
        {
            if (PlaceName != Constants.TruliaDbAddressNulls.NoPlaceName)
            {
                JSON = AddressParser.GetJsonMapResponse(PlaceName.Replace(Constants.GoogleStringRequestInDb.ByName, String.Empty), Constants.TypeOfMapGrabbing.ByAddress);
            }
            else
            {
                Console.WriteLine(PlaceName);
            }
            return JSON;
        }
    }
}
