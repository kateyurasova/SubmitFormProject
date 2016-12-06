using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSite.Pages
{
    class LoginPage : BasePage
    {
        private const string BASE_URL = "https://fs28.formsite.com/esDR1H/form1/index.html";
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.Name, Using = "Submit")]
        private IWebElement submitButton;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Login Page is opened");
        }

        public FormPage Login(String password)
        {
            passwordInput.SendKeys(password);
            submitButton.Click();
            return new FormPage(driver);
        }
    }
}
