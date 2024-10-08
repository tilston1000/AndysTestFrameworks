﻿using OpenQA.Selenium;
using POMFramework_keva61_.PageObjects.Base;
using POMFramework_keva61_.PageObjects.Home.Map;

namespace POMFramework_keva61_.PageObjects.Home
{
    // This class stores all of the methods available to the page class
    public class HomePage : BasePage
    {
        public readonly HomePageMap Map;

        public HomePage(IWebDriver driver) : base(driver)
        {
            // Creates a new mapping file when the page pbject is created
            Map = new HomePageMap(driver);
        }

        // Test methods available that are available to the test cases.
        public void GoTo()
        {
            Helper.GoToUrl("https://www.saucedemo.com/");
        }

        public void Login()
        {
            var username = Map.AcceptedUserNames.Text;
            var usernameResult = username.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Map.UsernameField.SendKeys(usernameResult[1]);

            var password = Map.AcceptedPasswords.Text;
            var passwordResult = password.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Map.PasswordField.SendKeys(passwordResult[1]);

            Map.LoginButton.Click();

            Helper.WaitForPageToLoad(Map.InventoryContainer);
        }

    }
}
