using FormSite.Pages;
using NUnit.Framework;

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

            Assert.AreEqual(loginErrorPage.GetErrorMessage(), 
                "Incorrect Password. Please try again.");
            Assert.AreEqual(loginErrorPage.GetErrorTitle(), "An error has occurred");

            // AND: User may return to Login page using Go Back link
            loginPage = loginErrorPage.ReturnToLoginPage();
            Assert.AreEqual(loginPage.GetTitle(), "James' form");
        }
    }
}
