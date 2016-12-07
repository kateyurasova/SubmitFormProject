using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using log4net;

namespace FormSite.Configuration
{
    public class Configuration
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Configuration));

        public static string GetProjectConfig(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException e)
            {
                logger.Warn("Unable to find" + key + " in App.config", e);
                return null;
            }
        }

        public static BrowserType ReadBrowserTypeFromConfig()
        {

            switch (GetProjectConfig("Browser"))
            {
                case "IE":
                    return BrowserType.IEXPLORER;
                    break;
                case "CHROME":
                    return BrowserType.CHROME;
                    break;
                default:
                    return BrowserType.FIREFOX;
                    break;
            }
        }
    }
}
