using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using FormSite.Driver;
using log4net;

namespace FormSite.API
{
    class APIUtils
    {
        private const int currentTestResultIndex = 0;
        private static readonly ILog logger = LogManager.GetLogger(typeof(DriverInstance));

        public fs_responseResultsResult getResultByReferenceNumber(String referenceNumber)
        {

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(fs_response));
                fs_response resultingMessage = (fs_response)serializer.Deserialize(WSManager.MakeRequest());
                foreach (var  result in resultingMessage.results)
                {
                    if (result.id.Equals(referenceNumber))
                    {
                        return result;
                    }
                }

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                //Console.Read();
                logger.Warn("Unable to get result by Reference Id", e);
            }
            return null;
        }
    }
}
