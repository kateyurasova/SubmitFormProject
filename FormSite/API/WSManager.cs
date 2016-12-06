using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FormSite.API
{
    class WSManager
    {
        private const string API_URL = 
            "https://fs28.formsite.com/api/users/esDR1H/forms/form1/results?fs_api_key=zvucTDw1ZXt0&fs_include_headings";


      public static Stream MakeRequest()
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(API_URL) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                StreamReader resStream = new StreamReader(response.GetResponseStream(), 
                    Encoding.GetEncoding("ISO-8859-1"));

                return resStream.BaseStream;
                /*XmlDocument xmlDoc = new XmlDocument();

                XmlDeclaration xmldecl;
                xmldecl = xmlDoc.CreateXmlDeclaration("1.0", null, null);
                xmldecl.Encoding = "ISO-8859-1";

                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);*/

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Read();
                return null;
            }
        }
    }
}
