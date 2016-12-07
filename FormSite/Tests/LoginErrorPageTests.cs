using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FormSite.Driver;
using FormSite.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FormSite.Tests
{
    [TestFixture]
    class LoginErrorPageTests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string INCORRECT_PASSWORD = "secret1";
       
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
        [Test, Description("Negative Test: User enters nonexistent password - Page with error message appears")]
        public void FailedLogin()
        {
            // WHEN: User loads the Login page and enter incorrect password
            LoginPage loginPage = new LoginPage();
            loginPage.OpenPage();
            loginPage.Login(INCORRECT_PASSWORD);

            // THEN: Error page with text message appears
            LoginErrorPage loginErrorPage = new LoginErrorPage();

            Assert.AreEqual(loginErrorPage.getErrorMessage(), 
                "Incorrect Password. Please try again.");
            Assert.AreEqual(loginErrorPage.getErrorTitle(), "An error has occurred");

            // AND: User may return to Login page using Go Back link
            loginPage = loginErrorPage.returnToLoginPage();
            Assert.AreEqual(loginPage.GetTitle(), "James' form");
        }
    }
}
