using System;
using System.Xml.Serialization;
using log4net;

namespace FormSite.API
{
    class APIUtils
    {
        private const int currentTestResultIndex = 0;
        private static readonly ILog logger = LogManager.GetLogger(typeof(APIUtils));

        public fs_responseResultsResult GetResultByReferenceNumber(String referenceNumber)
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
                logger.Warn("Unable to get result by Reference Id", e);
            }
            return null;
        }
    }
}
