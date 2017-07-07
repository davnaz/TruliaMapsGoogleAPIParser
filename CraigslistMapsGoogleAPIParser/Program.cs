﻿using TruliaMapsGoogleAPIParser.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruliaMapsGoogleAPIParser
{
    class Program
    {
        static void Main(string[] args)
        {


            //while (true)
            //{
            //    Console.WriteLine("Write a place name in USA for getting info:");
            //    Console.WriteLine(AddressParser.GetJsonMapResponse(Console.ReadLine(),Constants.TypeOfMapGrabbing.ByLatlng));
            //    Console.WriteLine("Do you wish to get info about another place? \nPress \"1\" to continue, any other to interrupt:");
            //    ConsoleKeyInfo k = Console.ReadKey();
            //    if(k.Key != ConsoleKey.D1)
            //    {
            //        Console.WriteLine("\nGoog Bye!");
            //        Console.ReadKey();
            //        return;
            //    }
            //
            //}
            AddressParser parser = new AddressParser();
            parser.StartGrabbing();
            //string json = "{    \"results\" : [       {          \"address_components\" : [             {                \"long_name\" : \"118\",                \"short_name\" : \"118\",                \"types\" : [ \"street_number\" ]             },             {                \"long_name\" : \"Broaddus Street\",                \"short_name\" : \"Broaddus St\",                \"types\" : [ \"route\" ]             },             {                \"long_name\" : \"Lufkin\",                \"short_name\" : \"Lufkin\",                \"types\" : [ \"locality\", \"political\" ]             },             {                \"long_name\" : \"Angelina County\",                \"short_name\" : \"Angelina County\",                \"types\" : [ \"administrative_area_level_2\", \"political\" ]             },             {                \"long_name\" : \"Texas\",                \"short_name\" : \"TX\",                \"types\" : [ \"administrative_area_level_1\", \"political\" ]             },             {                \"long_name\" : \"United States\",                \"short_name\" : \"US\",                \"types\" : [ \"country\", \"political\" ]             },             {                \"long_name\" : \"75901\",                \"short_name\" : \"75901\",                \"types\" : [ \"postal_code\" ]             }          ],          \"formatted_address\" : \"118 Broaddus St, Lufkin, TX 75901, USA\",          \"geometry\" : {             \"location\" : {                \"lat\" : 31.3494116,                \"lng\" : -94.6928006             },             \"location_type\" : \"ROOFTOP\",             \"viewport\" : {                \"northeast\" : {                   \"lat\" : 31.3507605802915,                   \"lng\" : -94.6914516197085                },                \"southwest\" : {                   \"lat\" : 31.3480626197085,                   \"lng\" : -94.69414958029151                }             }          },          \"place_id\" : \"ChIJrSqlQi89OIYRQpkIb2QUH7c\",          \"types\" : [ \"street_address\" ]       },       {          \"address_components\" : [             {                \"long_name\" : \"Lufkin\",                \"short_name\" : \"Lufkin\",                \"types\" : [ \"locality\", \"political\" ]             },             {                \"long_name\" : \"Angelina County\",                \"short_name\" : \"Angelina County\",                \"types\" : [ \"administrative_area_level_2\", \"political\" ]             },             {                \"long_name\" : \"Texas\",                \"short_name\" : \"TX\",                \"types\" : [ \"administrative_area_level_1\", \"political\" ]             },             {                \"long_name\" : \"United States\",                \"short_name\" : \"US\",                \"types\" : [ \"country\", \"political\" ]             }          ],          \"formatted_address\" : \"Lufkin, TX, USA\",          \"geometry\" : {             \"bounds\" : {                \"northeast\" : {                   \"lat\" : 31.379695,                   \"lng\" : -94.6782559                },                \"southwest\" : {                   \"lat\" : 31.26476409999999,                   \"lng\" : -94.77503710000001                }             },             \"location\" : {                \"lat\" : 31.3382406,                \"lng\" : -94.729097             },             \"location_type\" : \"APPROXIMATE\",             \"viewport\" : {                \"northeast\" : {                   \"lat\" : 31.379695,                   \"lng\" : -94.6782559                },                \"southwest\" : {                   \"lat\" : 31.26476409999999,                   \"lng\" : -94.77503710000001                }             }          },          \"place_id\" : \"ChIJsbOqGT03OIYRSb8SwfR5Q0k\",          \"types\" : [ \"locality\", \"political\" ]       },       {          \"address_components\" : [             {                \"long_name\" : \"75901\",                \"short_name\" : \"75901\",                \"types\" : [ \"postal_code\" ]             },             {                \"long_name\" : \"Lufkin\",                \"short_name\" : \"Lufkin\",                \"types\" : [ \"locality\", \"political\" ]             },             {                \"long_name\" : \"Angelina County\",                \"short_name\" : \"Angelina County\",                \"types\" : [ \"administrative_area_level_2\", \"political\" ]             },             {                \"long_name\" : \"Texas\",                \"short_name\" : \"TX\",                \"types\" : [ \"administrative_area_level_1\", \"political\" ]             },             {                \"long_name\" : \"United States\",                \"short_name\" : \"US\",                \"types\" : [ \"country\", \"political\" ]             }          ],          \"formatted_address\" : \"Lufkin, TX 75901, USA\",          \"geometry\" : {             \"bounds\" : {                \"northeast\" : {                   \"lat\" : 31.482505,                   \"lng\" : -94.541657                },                \"southwest\" : {                   \"lat\" : 31.1039179,                   \"lng\" : -94.87966209999999                }             },             \"location\" : {                \"lat\" : 31.3382166,                \"lng\" : -94.6657027             },             \"location_type\" : \"APPROXIMATE\",             \"viewport\" : {                \"northeast\" : {                   \"lat\" : 31.482505,                   \"lng\" : -94.541657                },                \"southwest\" : {                   \"lat\" : 31.1039179,                   \"lng\" : -94.75184689999999                }             }          },          \"place_id\" : \"ChIJqSWndK0YOIYR_iDkf8waoYA\",          \"types\" : [ \"postal_code\" ]       },       {          \"address_components\" : [             {                \"long_name\" : \"Lufkin, TX\",                \"short_name\" : \"Lufkin, TX\",                \"types\" : [ \"political\" ]             },             {                \"long_name\" : \"Angelina County\",                \"short_name\" : \"Angelina County\",                \"types\" : [ \"administrative_area_level_2\", \"political\" ]             },             {                \"long_name\" : \"Texas\",                \"short_name\" : \"TX\",                \"types\" : [ \"administrative_area_level_1\", \"political\" ]             },             {                \"long_name\" : \"United States\",                \"short_name\" : \"US\",                \"types\" : [ \"country\", \"political\" ]             }          ],          \"formatted_address\" : \"Lufkin, TX, TX, USA\",          \"geometry\" : {             \"bounds\" : {                \"northeast\" : {                   \"lat\" : 31.526956,                   \"lng\" : -94.129632                },                \"southwest\" : {                   \"lat\" : 31.026384,                   \"lng\" : -95.005549                }             },             \"location\" : {                \"lat\" : 31.2704698,                \"lng\" : -94.64503499999999             },             \"location_type\" : \"APPROXIMATE\",             \"viewport\" : {                \"northeast\" : {                   \"lat\" : 31.526956,                   \"lng\" : -94.129632                },                \"southwest\" : {                   \"lat\" : 31.026384,                   \"lng\" : -95.005549                }             }          },          \"place_id\" : \"ChIJ52zDgXE5OIYRjbzKt8wEPus\",          \"types\" : [ \"political\" ]       },       {          \"address_components\" : [             {                \"long_name\" : \"Angelina County\",                \"short_name\" : \"Angelina County\",                \"types\" : [ \"administrative_area_level_2\", \"political\" ]             },             {                \"long_name\" : \"Texas\",                \"short_name\" : \"TX\",                \"types\" : [ \"administrative_area_level_1\", \"political\" ]             },             {                \"long_name\" : \"United States\",                \"short_name\" : \"US\",                \"types\" : [ \"country\", \"political\" ]             }          ],          \"formatted_address\" : \"Angelina County, TX, USA\",          \"geometry\" : {             \"bounds\" : {                \"northeast\" : {                   \"lat\" : 31.526916,                   \"lng\" : -94.129632                },                \"southwest\" : {                   \"lat\" : 31.0260881,                   \"lng\" : -95.005566                }             },             \"location\" : {                \"lat\" : 31.2704698,                \"lng\" : -94.64503499999999             },             \"location_type\" : \"APPROXIMATE\",             \"viewport\" : {                \"northeast\" : {                   \"lat\" : 31.526916,                   \"lng\" : -94.16901159999999                },                \"southwest\" : {                   \"lat\" : 31.0260881,                   \"lng\" : -95.005566                }             }          },          \"place_id\" : \"ChIJbWUFnLAwOIYRDxGvxNngXxE\",          \"types\" : [ \"administrative_area_level_2\", \"political\" ]       },       {          \"address_components\" : [             {                \"long_name\" : \"Texas\",                \"short_name\" : \"TX\",                \"types\" : [                   \"administrative_area_level_1\",                   \"establishment\",                   \"point_of_interest\",                   \"political\"                ]             },             {                \"long_name\" : \"United States\",                \"short_name\" : \"US\",                \"types\" : [ \"country\", \"political\" ]             }          ],          \"formatted_address\" : \"Texas, USA\",          \"geometry\" : {             \"bounds\" : {                \"northeast\" : {                   \"lat\" : 36.5007041,                   \"lng\" : -93.5080389                },                \"southwest\" : {                   \"lat\" : 25.8371638,                   \"lng\" : -106.6456461                }             },             \"location\" : {                \"lat\" : 31.9685988,                \"lng\" : -99.9018131             },             \"location_type\" : \"APPROXIMATE\",             \"viewport\" : {                \"northeast\" : {                   \"lat\" : 36.5018864,                   \"lng\" : -93.5080389                },                \"southwest\" : {                   \"lat\" : 25.83819,                   \"lng\" : -106.6452951                }             }          },          \"place_id\" : \"ChIJSTKCCzZwQIYRPN4IGI8c6xY\",          \"types\" : [             \"administrative_area_level_1\",             \"establishment\",             \"point_of_interest\",             \"political\"          ]       },       {          \"address_components\" : [             {                \"long_name\" : \"United States\",                \"short_name\" : \"US\",                \"types\" : [ \"country\", \"political\" ]             }          ],          \"formatted_address\" : \"United States\",          \"geometry\" : {             \"bounds\" : {                \"northeast\" : {                   \"lat\" : 71.5388001,                   \"lng\" : -66.885417                },                \"southwest\" : {                   \"lat\" : 18.7763,                   \"lng\" : 170.5957                }             },             \"location\" : {                \"lat\" : 37.09024,                \"lng\" : -95.712891             },             \"location_type\" : \"APPROXIMATE\",             \"viewport\" : {                \"northeast\" : {                   \"lat\" : 49.38,                   \"lng\" : -66.94                },                \"southwest\" : {                   \"lat\" : 25.82,                   \"lng\" : -124.39                }             }          },          \"place_id\" : \"ChIJCzYy5IS16lQRQrfeQ5K5Oxw\",          \"types\" : [ \"country\", \"political\" ]       }    ],    \"status\" : \"OK\" } ";
            //string json = "{   'error_message' : 'You have exceeded your daily request quota for this API. We recommend registering for a key at the Google Developers Console: https://console.developers.google.com/apis/credentials?project=_',   'results' : [],  'status' : 'OVER_QUERY_LIMIT'  }";
            //GeocodeJsonObject o = AddressParser.ReadJsonToObject(json);
            //RooftopResultPlace place = new RooftopResultPlace(o);
            parser.ConvertJsonStringFromDbToCells();
            Console.ReadKey();

            
        }
    }
}
