using OpenQA.Selenium;
using POMFramework_keva61_.PageObjects.Base;
using POMFramework_keva61_.Utilities;

namespace POMFramework_keva61_.PageObjects.Home.Map
{
    // This class stores the locators to all of the elements that can be interacted with on the page
    public class HomePageMap : BasePage
    {
        public HomePageMap(IWebDriver driver) : base(driver)
        {
        }

        // Page elements used for synchronisation
        public By InventoryContainer => By.Id("inventory_container");

        // Page elements for interaction
        public IWebElement UsernameField => Helper.LocateElement(Locators.ID, "user-name");
        public IWebElement AcceptedUserNames => Helper.LocateElement(Locators.ID, "login_credentials");
        public IWebElement AcceptedPasswords => Helper.LocateElement(Locators.ClassName, "login_password");
        public IWebElement PasswordField => Helper.LocateElement(Locators.ID, "password");
        public IWebElement LoginButton => Helper.LocateElement(Locators.ClassName, "btn_action");
    }
}