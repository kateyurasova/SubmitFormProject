using System;
using FormSite.Driver;

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
