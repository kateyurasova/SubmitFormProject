using System;
using System.IO;
using System.Net;
using FormSite.Driver;
using log4net;

namespace FormSite.API
{
    class WSManager
    {
        private const string API_URL = 
            "https://fs28.formsite.com/api/users/esDR1H/forms/form1/results?fs_api_key=zvucTDw1ZXt0&fs_include_headings";
        private static readonly ILog logger = LogManager.GetLogger(typeof(DriverInstance));

        public static Stream MakeRequest()
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(API_URL) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                StreamReader resStream = new StreamReader(response.GetResponseStream()); 
                    //Encoding.GetEncoding("ISO-8859-1"));

                return resStream.BaseStream;
            }
            catch (Exception e)
            {
                logger.Warn("Unable to get the data from API", e);
                return null;
            }
        }
    }
}
