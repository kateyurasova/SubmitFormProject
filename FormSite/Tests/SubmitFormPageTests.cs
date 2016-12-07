using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FormSite.API;
using FormSite.Driver;
using FormSite.Pages;
using FormSite.Utils;

namespace FormSite
{
    [TestFixture]
    public class SubmitFormPageTests
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
            steps.LoginFormSite(PASSWORD);
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test, Description("Positive Test: User submit the Data on the form - Data should be saved")]
        public void submitDataTest()
        {
            //SETUP: Generate testing data
            string firstname = "firstname" + Utils.RandomGenerator.GetRandomString(50);
            string lastname = "lastname" + Utils.RandomGenerator.GetRandomString(50);
            string email = "email" + Utils.RandomGenerator.GetRandomString(10) + "@gmail.com";
            string date = "2016-12-01";
            string interestDescription = "interestDescription" + Utils.RandomGenerator.GetRandomString(100);

            // GIVEN: User logs into the Web Site
            Pages.SubmitFormPage submitFormPage = new SubmitFormPage();

            // WHEN: User fills in the form and perform Submit on the page
            SuccessPage successPage = submitFormPage.SubmitData(firstname, lastname, email, date, interestDescription);
                
            // THEN: Text about successfull submit is presented on the page
            Assert.True(successPage.GetResponseText().
                Equals("Your form has been successfully submitted. Thank you for your time."));

            // AND: Data received from API contains submitted values
            fs_responseResultsResult currentTestResult = new APIUtils().
                getResultByReferenceNumber(successPage.GetReferenceNumber());

            Assert.NotNull(currentTestResult, "Response does not contain submitted data");
            Assert.AreEqual(currentTestResult.items[FIRSTNAME_INDEX].value, firstname,
                "FistName is incorrect");
            Assert.AreEqual(currentTestResult.items[LASTNAME_INDEX].value, lastname,
                "Lastname is incorrect");
            Assert.AreEqual(currentTestResult.items[EMAIL_INDEX].value, email,
                "Email is incorrect");
            Assert.AreEqual(currentTestResult.items[DATE_INDEX].value, date,
                "Date is incorrect");
            Assert.AreEqual(currentTestResult.items[INTEREST_DESCRIPTION_INDEX].value, interestDescription,
                "Interest Description is incorrect");

        }

        [Test, Description("Negative Test: User does not enter lastname - Response Required should be presented")]
        public void firstNameWarningMessageTest()
        {
            // SETUP: Generate Testing Data
            string firstname = "firstname" + Utils.RandomGenerator.GetRandomString(50);
            string email = "email" + Utils.RandomGenerator.GetRandomString(10) + "@gmail.com";
            string date = "2016-12-01";
            string interestDescription = "interestDescription" + Utils.RandomGenerator.GetRandomString(100);

            // GIVEN: User goes to Web Site Form
            Pages.SubmitFormPage submitFormPage = new SubmitFormPage();

            // WHEN: User fills in the form and perform Submit on the page
            submitFormPage.SubmitData(firstname, "", email, date, interestDescription);

            // THEN: Text about successfull submit is presented on the page
            Assert.AreEqual(submitFormPage.GetRequiredFieldsWarningText(), 
                "Please review the form and correct the highlighted items.");

            Assert.AreEqual(submitFormPage.GetLastnameWarningText(),
                           "Response Required");

        }

        [Test, Description("Negative Test: User does not enter firstname - Response Required should be presented")]
        public void requiredFieldsWarningMessageTest()
        {
            // SETUP: Generate Testing Data
            string lastname = "lastname" + Utils.RandomGenerator.GetRandomString(50);
            string email = "email" + Utils.RandomGenerator.GetRandomString(10) + "@gmail.com";
            string date = "2016-12-01";
            string interestDescription = "interestDescription" + Utils.RandomGenerator.GetRandomString(100);

            // GIVEN: User goes to Web Site Form
            Pages.SubmitFormPage submitFormPage = new SubmitFormPage();

            // WHEN: User fills in the form and perform Submit on the page
            submitFormPage.SubmitData("", lastname, email, date, interestDescription);

            // THEN: Text about successfull submit is presented on the page
            Assert.AreEqual(submitFormPage.GetFirstNameWarningText(),
                           "Response Required");

        }
    }
}
