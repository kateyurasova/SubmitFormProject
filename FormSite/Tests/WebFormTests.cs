using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FormSite.Pages;
using FormSite.Utils;

namespace FormSite
{
    [TestFixture]
    public class WebFormTests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string PASSWORD = "secret";
        
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
            SuccessPage successPage = formPage.SubmitData("firstname" + Utils.RandomGenerator.GetRandomString(50), 
                "lastname" + Utils.RandomGenerator.GetRandomString(50), 
                "email" + Utils.RandomGenerator.GetRandomString(10) + "@gmail.com",
                "2016-12-01", 
                "interestDescription" + Utils.RandomGenerator.GetRandomString(100));

            // THEN: Text about successfull submit is presented on the page
            Assert.True(successPage.GetResponseText().
                Equals("Your form has been successfully submitted. Thank you for your time."));
            
        }

        /*
         *  [Values(arg1: string.Concat("firstnameTest", RandomGenerator.GetRandomString(50)), arg2: "firstnameTest2")] string firstname,
            [Values("lastnameTest1", "lastnameTest2")] string lastname,
            [Values("emailTest1@gmail.com", "emailTest2@gmail.com")] string email,
            [Values("2016-12-01", "2016-12-01")] string date,
            [Values("interest description1", "interest description2")] string interest)
         */

        //Assert.True(steps.IsLoggedIn());
        // [Test]

    }
}
