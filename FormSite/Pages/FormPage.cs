using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSite.Pages
{
    class FormPage
    {
        private const string BASE_URL = "https://fs28.formsite.com/res/formPassword";
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "RESULT_TextField-0")]
        private IWebElement firstnameInput;

        [FindsBy(How = How.Id, Using = "RESULT_TextField-1")]
        private IWebElement lastnameInput;

        [FindsBy(How = How.Id, Using = "RESULT_TextField-2")]
        private IWebElement emailAddressInput;

        [FindsBy(How = How.Id, Using = "RESULT_TextField-3")]
        private IWebElement dateInput;

        [FindsBy(How = How.Id, Using = "RESULT_TextField-4")]
        private IWebElement interestsTextArea;

        [FindsBy(How = How.Id, Using = "FSsubmit")]
        private IWebElement submitButton;

        public FormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void submitData(String firstname, String lastname, String emailAddress,
            String date, String intrests)
        {
            firstnameInput.SendKeys(firstname);
            lastnameInput.SendKeys(lastname);
            emailAddressInput.SendKeys(emailAddress);
            dateInput.SendKeys(date);
            interestsTextArea.SendKeys(intrests);
            submitButton.Click();
        }
    }
}
