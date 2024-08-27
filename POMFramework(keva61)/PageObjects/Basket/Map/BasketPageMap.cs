using OpenQA.Selenium;
using POMFramework_keva61_.PageObjects.Base;
using POMFramework_keva61_.Utilities;

namespace POMFramework_keva61_.PageObjects.Basket.Map
{
    public class BasketPageMap : BasePage
    {
        public BasketPageMap(IWebDriver driver) : base(driver)
        {
            
        }

        // Page elements used for synchronisation
        public By CartItem => By.ClassName("cart_item");


        // page elements used for interaction
        public IWebElement RemoveButton => Helper.LocateElement(Locators.ID, "remove-sauce-labs-backpack");
        //public IWebElement BasketTable => Helper.LocateElement(Locators.ClassName, "cart_list");
        public IWebElement ItemOneName => Helper.LocateElement(Locators.ClassName, "inventory_item_name");
        public IWebElement CheckoutButton => Helper.LocateElement(Locators.Xpath, "//button[contains(text(),'Checkout')]");
    }
}
