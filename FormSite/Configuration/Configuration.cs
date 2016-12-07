using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FormSite.Configuration
{
    public class Configuration
    {
        public static string GetProjectConfig(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                Console.WriteLine(result);
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
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
