using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormSite.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FormSite.Pages
{
    class LoginErrorPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "content")]
        private IWebElement errorResponseSpan;

        [FindsBy(How = How.ClassName, Using = "segment_header")]
        private IWebElement errorTitleDiv;

        [FindsBy(How = How.LinkText, Using = "Go Back")]
        private IWebElement goBackLink;


        public LoginErrorPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public LoginErrorPage()
        {
            this.driver = DriverInstance.GetInstance();
            PageFactory.InitElements(this.driver, this);
        }

        public string getErrorTitle()
        {
            return errorTitleDiv.Text;
        }

        public string getErrorMessage()
        {
            return errorResponseSpan.Text;
        }

        public LoginPage returnToLoginPage()
        {
            goBackLink.Click();
            return new LoginPage();
        }
    }
}
