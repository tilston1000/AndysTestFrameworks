﻿using OpenQA.Selenium;
using POMFramework_keva61_.PageObjects.Base;
using POMFramework_keva61_.Utilities;

namespace POMFramework_keva61_.PageObjects.Checkout.Map
{
    internal class CheckoutPageMap : BasePage
    {
        public CheckoutPageMap(IWebDriver driver) : base(driver)
        {
        }

        public By CheckoutContainer => By.ClassName("checkout_info");
        public By SummaryContainer => By.Id("checkout_summary_container");

        public IWebElement FirstNameField => Helper.LocateElement(Locators.ID, "first-name");
        public IWebElement LastnameField => Helper.LocateElement(Locators.ID, "last-name");
        public IWebElement PostalcodeField => Helper.LocateElement(Locators.ID, "postal-code");
        public IWebElement ContinueButton => Helper.LocateElement(Locators.Xpath, "//input[(@type='submit')]");
        public IWebElement FinishCheckoutButton => Helper.LocateElement(Locators.Xpath, "//button[contains(text(), 'Finish')]");
        public IWebElement PonyExpressImage => Helper.LocateElement(Locators.ClassName, "pony_express");
    }
}