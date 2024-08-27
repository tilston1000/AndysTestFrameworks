using AndysTestFrameworks.DemoQA.PageObjects.Base;
using AndysTestFrameworks.DemoQA.Utilities;
using OpenQA.Selenium;

namespace AndysTestFrameworks.DemoQA.PageObjects.Login.Map
{
    public class LoginPageMap : BasePage
    {
        public LoginPageMap(IWebDriver driver) : base(driver)
        {
        }

        // Page elements used for interaction
        public IWebElement UsernameTextBox => Helpers.LocateElement(Locators.ID, "userName");
        public IWebElement PasswordTextBox => Helpers.LocateElement(Locators.ID, "password");
        public IWebElement LoginButton => Helpers.LocateElement(Locators.ID, "login");
    }
}
