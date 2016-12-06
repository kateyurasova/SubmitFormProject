using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FormSite.API
{
    class APIUtils
    {
        private const int currentTestResultIndex = 0;
        public fs_responseResultsResult getCurrentTestResult()
        {

            try
            {
                //Create the REST Services 'Find Location by Query' request
                //XmlDocument testResultsResponse = WSManager.MakeRequest();

                //Stream stream = new MemoryStream();
                //testResultsResponse.Save(WSManager.MakeRequest());
                XmlSerializer serializer = new XmlSerializer(typeof(fs_response));
                fs_response resultingMessage = (fs_response)serializer.Deserialize(WSManager.MakeRequest());
                return resultingMessage.results[currentTestResultIndex];
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
