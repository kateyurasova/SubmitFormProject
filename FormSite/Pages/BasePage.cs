using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FormSite.Driver;
using OpenQA.Selenium;

namespace FormSite.Pages
{
    class BasePage
    {
        public void OpenPage(String url)
        {
            DriverInstance.GetInstance().Navigate().GoToUrl(url);
        }

    }
}
