using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormSite.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FormSite.Pages
{
    class BasePage
    {
        public void OpenPage(String url)
        {
            DriverInstance.GetInstance().Navigate().GoToUrl(url);
        }

        protected async Task PageLoad()
        {
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(DriverInstance.GetInstance(), 
                TimeSpan.FromSeconds(Convert.ToDouble(Configuration.Configuration.GetProjectConfig("TimeoutSeconds"))));
            wait.Until(driver1 => ((IJavaScriptExecutor) DriverInstance.GetInstance()).
            ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}
