using FormSite.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FormSite.Pages
{
    class LoginErrorPage : BasePage
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

        public string GetErrorTitle()
        {
            DriverInstance.FindElement(By.ClassName("segment_header"),
                 Configuration.Configuration.GetTimeOut());
            return errorTitleDiv.Text;
        }

        public string GetErrorMessage()
        {
            DriverInstance.FindElement(By.LinkText("Go Back"),
                Configuration.Configuration.GetTimeOut());
            return errorResponseSpan.Text;
        }

        public LoginPage ReturnToLoginPage()
        {
            goBackLink.Click();
            return new LoginPage();
        }
    }
}
