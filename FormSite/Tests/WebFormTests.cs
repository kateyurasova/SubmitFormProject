using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FormSite.API;
using FormSite.Pages;
using FormSite.Utils;

namespace FormSite
{
    [TestFixture]
    public class WebFormTests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string PASSWORD = "secret";

        private const int FIRSTNAME_INDEX = 0;
        private const int LASTNAME_INDEX = 1;
        private const int EMAIL_INDEX = 2;
        private const int DATE_INDEX = 3;
        private const int INTEREST_DESCRIPTION_INDEX = 4;

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test, Description("Positive Test: User submit the Data on the form - Data should be saved")]
        public void submitDataTest()
        {
            // GIVEN: User logs into the Web Site
            Pages.FormPage formPage = steps.LoginFormSite(PASSWORD);

            // WHEN: User fills in the form and perform Submit on the page
            string firstname = "firstname" + Utils.RandomGenerator.GetRandomString(50);
            string lastname = "lastname" + Utils.RandomGenerator.GetRandomString(50);
            string email = "email" + Utils.RandomGenerator.GetRandomString(10) + "@gmail.com";
            string date = "2016-12-01";
            string interestDescription = "interestDescription" + Utils.RandomGenerator.GetRandomString(100);


            SuccessPage successPage = formPage.SubmitData(firstname, lastname, email, date, interestDescription);
                
            // THEN: Text about successfull submit is presented on the page
            Assert.True(successPage.GetResponseText().
                Equals("Your form has been successfully submitted. Thank you for your time."));

            // AND: Data received from API contains submitted values
            fs_responseResultsResult currentTestResult = new APIUtils().getCurrentTestResult();

            Assert.AreEqual(currentTestResult.items[FIRSTNAME_INDEX].value, firstname);
            Assert.AreEqual(currentTestResult.items[LASTNAME_INDEX].value, lastname );
            Assert.AreEqual(currentTestResult.items[EMAIL_INDEX].value, email);
            Assert.AreEqual(currentTestResult.items[DATE_INDEX].value, date);
            Assert.AreEqual(currentTestResult.items[INTEREST_DESCRIPTION_INDEX].value, interestDescription);

        }
    }
}
