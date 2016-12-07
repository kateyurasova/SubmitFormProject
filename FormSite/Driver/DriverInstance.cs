using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormSite.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace FormSite.Driver
{
    class DriverInstance
    {
        private static IWebDriver driver;

        private DriverInstance() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = CreateDriver();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            switch (Configuration.Configuration.ReadBrowserTypeFromConfig())
            {
                case BrowserType.FIREFOX:
                {
                    foreach (Process p in System.Diagnostics.Process.
                        GetProcessesByName("Firefox"))
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeou

                    }
                    foreach (Process p in System.Diagnostics.Process.
                        GetProcessesByName("geckodriver.exe"))
                    {
                        p.Kill();
                        p.WaitForExit();
                    }
                }
                break;
                /*case BrowserType.CHROME:
                    driver.Quit();
                    break;
                case BrowserType.IEXPLORER:
                    driver.Quit();
                    break;*/
            }
            driver.Quit();
            driver = null;
        }

        private static IWebDriver CreateDriver()
        {
            IWebDriver driver;
            switch (Configuration.Configuration.ReadBrowserTypeFromConfig())
            {
                case BrowserType.IEXPLORER:
                    driver = new InternetExplorerDriver();
                    break;
                case BrowserType.CHROME:
                    driver = new ChromeDriver();
                    break;
                default:
                    driver = new FirefoxDriver();
                    break;
            }

            return driver;
        }
    }
}
