using OpenQA.Selenium;
using POMFramework_keva61_.PageObjects.Base;
using POMFramework_keva61_.Utilities;

namespace POMFramework_keva61_.PageObjects.Inventory.Map
{
    public class InventoryPageMap : BasePage
    {
        public InventoryPageMap(IWebDriver driver) : base(driver)
        {
        }

        // Page elements used for synchronisation
        public By SlideOutMenu => By.ClassName("bm-item-list");
        public By BotImg => By.ClassName("bot_column");

        // Page elements used for interaction
        public IWebElement HamburgerMenu => Helper.LocateElement(Locators.ClassName, "bm-burger-button");
        public IWebElement LogoutLink => Helper.LocateElement(Locators.Xpath, "//*[@id=\"logout_sidebar_link\"]");
        public IWebElement ProductSort => Helper.LocateElement(Locators.ClassName, "product_sort_container");
        public IList<IWebElement> AddItemToCart => Helper.LocateElements(Locators.Xpath, "//button[contains(text(), 'Add to cart')]");
        public IWebElement ShoppingCart => Helper.LocateElement(Locators.Xpath, "//*[@id=\"shopping_cart_container\"]/a/span");
        public IEnumerable<IWebElement> AllStoreItems => Helper.LocateElements(Locators.Xpath, "//div[@class=\"inventory_item\"]//button");
        public IList<IWebElement> RemoveItemFromCart => Helper.LocateElements(Locators.Xpath, "//button[contains(text(), 'Remove')]");
    }
}