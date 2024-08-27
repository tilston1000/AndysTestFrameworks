using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POMFramework_keva61_.PageObjects.Base;
using POMFramework_keva61_.PageObjects.Inventory.Map;

namespace POMFramework_keva61_.PageObjects.Inventory
{
    // This object stores all the methods available to the page object
    public class InventoryPage : BasePage
    {
        public readonly InventoryPageMap Map;

        public InventoryPage(IWebDriver driver) : base(driver) 
        {
            Map = new InventoryPageMap(driver);
        }

        public void Logout()
        {
            Map.HamburgerMenu.Click();
            Helper.WaitForPageToLoad(Map.SlideOutMenu);
            Map.LogoutLink.Click();
            //Helper.WaitForPageToLoad(Map.BotImg);
        }

        public void AddAllItemsToCart()
        {
            foreach (var button in Map.AllStoreItems)
            {
                button.Click();
            }
        }

        public void SortByMostExpensive()
        {
            var select = new SelectElement(Map.ProductSort);
            select.SelectByValue("hilo");
        }

        public void AddItemToCart()
        {
            Map.AddItemToCart[0].Click();
            Helper.WaitForTextToBePresent(Map.ShoppingCart, "1");
        }

        public void AddItemTwoToCart()
        {
            Map.AddItemToCart[0].Click();
            Helper.WaitForTextToBePresent(Map.ShoppingCart, "2");
        }

        public void RemoveItemTwoFromCart()
        {
            Map.RemoveItemFromCart[1].Click();
            Helper.WaitForTextToBePresent(Map.ShoppingCart, "1");
        }

        public void RemoveItemOneFromCart()
        {
            Map.RemoveItemFromCart[0].Click();
            try
            {
                Helper.WaitForTextToBePresent(Map.ShoppingCart, "irelevant, as no item exists");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element not found, as all items have been removed from minicart.");
            }
        }

        public void NavigateToCheckout()
        {
            Map.ShoppingCart.Click();
        }

        public void Checkout()
        {
            Map.ShoppingCart.Click();
        }
    }
}
