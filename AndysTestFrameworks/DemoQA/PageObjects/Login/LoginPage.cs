using AndysTestFrameworks.DemoQA.PageObjects.Base;
using AndysTestFrameworks.DemoQA.PageObjects.Login.Map;
using OpenQA.Selenium;

namespace AndysTestFrameworks.DemoQA.PageObjects.Login
{
    // This class stores all of the methods available to the page class
    public class LoginPage : BasePage
    {
        public readonly LoginPageMap Map;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            // Creates a new mapping file when the page object is created
            Map = new LoginPageMap(driver);
        }

        // Test methods available that are available to the test cases.
        public void LoginToApplication()
        {

            Map.UsernameTextBox.SendKeys("TestUser_1");
            Map.PasswordTextBox.SendKeys("Test@123");
            Map.LoginButton.Click();
        }

        public void GoTo()
        {
            Helpers.GoToUrl("https://demoqa.com/login");
        }
    }
}
