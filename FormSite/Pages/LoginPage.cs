using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using FormSite.Driver;
using OpenQA.Selenium.Support.UI;
using log4net;

namespace FormSite.Pages
{
    class LoginPage : BasePage
    {
        private const string BASE_URL = "https://fs28.formsite.com/esDR1H/form1/index.html";
        private static readonly ILog logger = LogManager.GetLogger(typeof(LoginPage));
        private IWebDriver driver;

        private const string TITLE = "James' form";

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.Name, Using = "Submit")]
        private IWebElement submitButton;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public LoginPage()
        {
            this.driver = DriverInstance.GetInstance();
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            logger.Info("Login page is opened");
        }

        public void Login(String password)
        {
            passwordInput.SendKeys(password);
            submitButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
        }

        public string GetTitle()
        {
            return TITLE;
        }
    }
}
