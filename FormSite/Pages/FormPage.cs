using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace FormSite.Pages
{
    class FormPage : BasePage
    {
        private const string BASE_URL = "https://fs28.formsite.com/esDR1H/form1/index.html";
        private const string TITLE = "James' form";
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "RESULT_TextField-0")]
        private IWebElement firstnameInput;

        [FindsBy(How = How.Id, Using = "RESULT_TextField-1")]
        private IWebElement lastnameInput;

        [FindsBy(How = How.Id, Using = "RESULT_TextField-2")]
        private IWebElement emailAddressInput;

        [FindsBy(How = How.Id, Using = "RESULT_TextField-3")]
        private IWebElement dateInput;

        [FindsBy(How = How.Name, Using = "RESULT_TextArea-4")]
        private IWebElement interestsTextArea;

        [FindsBy(How = How.Id, Using = "FSsubmit")]
        private IWebElement submitButton;

        public FormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public String GetUrl()
        {
            return BASE_URL;
        }

        public SuccessPage SubmitData(String firstname, String lastname, String emailAddress,
            String date, String intrestDescription)
        {
            firstnameInput.SendKeys(firstname);
            lastnameInput.SendKeys(lastname);
            emailAddressInput.SendKeys(emailAddress);
            dateInput.SendKeys(date);
            interestsTextArea.SendKeys(intrestDescription);
            submitButton.Click();
            return new SuccessPage(driver);
        }

        public void OpenPage(String url)
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Form Page is opened");
        }

        public string GetTitle()
        {
            return TITLE;
        }
    }
}
