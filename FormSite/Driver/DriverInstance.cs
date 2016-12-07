using OpenQA.Selenium;
using System;
using System.ComponentModel;
using System.Diagnostics;
using FormSite.Configuration;
using log4net;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace FormSite.Driver
{
    class DriverInstance
    {
        private static IWebDriver driver;
        private static readonly ILog logger = LogManager.GetLogger(typeof(DriverInstance));
       
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
                            try
                            {
                                p.Kill();
                                p.WaitForExit();
                            }
                            catch (Exception exception)
                            {
                                logger.Warn("Unable to terminate Firefox process", exception);
                            }
                        }
                        break;
                }
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

        public static IWebElement FindElement(By by, int timeoutInSeconds)
        {
            IWebDriver webDriver = GetInstance();
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
