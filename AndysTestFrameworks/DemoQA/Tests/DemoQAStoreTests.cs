using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace AndysTestFrameworks.DemoQA.TestCases
{
    public class DemoQAStoreTests
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void BasicLoginLogoutTestsWithWebDriverWait()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/login");

            var userNameTextBox = _driver.FindElement(By.Id("userName"));
            userNameTextBox.SendKeys("testuser_1");

            var passwordTextBox = _driver.FindElement(By.Id("password"));
            passwordTextBox.SendKeys("Test@123");

            var loginButton = _driver.FindElement(By.Id("login"));
            loginButton.Click();


            // Implementing a wait, as the username, when logged in, takes a while to
            // appear. This can cause the test to fail
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            Func<IWebDriver, IWebElement> waitForElement = new Func<IWebDriver, IWebElement>((Web) =>
            {
                Debug.WriteLine("Waiting for username to appear");
                IWebElement userNameValueWhenLoggedIn = _driver.FindElement(By.Id("userName-value"));
                if (userNameValueWhenLoggedIn.Displayed)
                {
                    return userNameValueWhenLoggedIn;
                }
                return null!;
            });
            IWebElement userNameValueWhenLoggedIn = wait.Until(waitForElement);
            Debug.WriteLine("Username is: " + userNameValueWhenLoggedIn.Text);

            var expectedUserNameWhenLoggedIn = "testuser_1";
            Assert.AreEqual(expectedUserNameWhenLoggedIn, userNameValueWhenLoggedIn.Text);

            var logoutButton = _driver.FindElement(By.Id("submit"));
            logoutButton.Click();

            var expectedLoginPageTextWhenLoggedOut = "Login";
            var actualLoginPageTextWhenLoggedOut = _driver.FindElement(By.ClassName("text-center"));
            Assert.AreEqual(expectedLoginPageTextWhenLoggedOut, actualLoginPageTextWhenLoggedOut.Text);
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Close();
        }

    }
}
