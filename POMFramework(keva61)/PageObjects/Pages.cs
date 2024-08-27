using OpenQA.Selenium;
using POMFramework_keva61_.PageObjects.Basket;
using POMFramework_keva61_.PageObjects.Checkout;
using POMFramework_keva61_.PageObjects.Home;
using POMFramework_keva61_.PageObjects.Inventory;
using POMFramework_keva61_.Tests.Base;

namespace POMFramework_keva61_.PageObjects
{
    internal class Pages : BaseTest
    {
        // This class is utilised by giving all of the page objects values
        // when the initialise method is called prior to the tests execution.
        // When this occurs, they can be referenced in the tests.
        public static HomePage Home;
        public static InventoryPage Inventory;
        public static CheckoutPage Checkout;
        public static BasketPage Basket;

        public static void Init(IWebDriver driver)
        {
            Home = new HomePage(driver);
            Inventory = new InventoryPage(driver);
            Checkout = new CheckoutPage(driver);
            Basket = new BasketPage(driver);
        }
    }
}