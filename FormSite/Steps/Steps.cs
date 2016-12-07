using log4net;
using OpenQA.Selenium;
using System;
using FormSite.Pages;

namespace FormSite.Steps
{
    class Steps
    {
        IWebDriver driver;
        private static readonly ILog logger = LogManager.GetLogger(typeof(Steps));

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginFormSite(String password)
        {
            logger.Info("Log in to Web Form Site");
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login(password);
        }

        public bool IsLoggedIn()
        {
            return driver.Title.Equals(value: new SubmitFormPage(driver).GetTitle());
        }
    }
}
