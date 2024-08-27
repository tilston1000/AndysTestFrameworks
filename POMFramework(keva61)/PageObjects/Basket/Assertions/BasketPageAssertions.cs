using OpenQA.Selenium;
using POMFramework_keva61_.PageObjects.Base;
using POMFramework_keva61_.PageObjects.Basket.Map;

namespace POMFramework_keva61_.PageObjects.Basket.Assertions
{
    public class BasketPageAssertions : BasePage
    {
        public readonly BasketPageMap Map;

        public BasketPageAssertions(IWebDriver driver) : base(driver)
        {
            Map = new BasketPageMap(driver);
        }

        internal void ValidateBasketHasOneItem()
        {
            Assert.That(Pages.Basket.Map.ItemOneName.Text == "Sauce Labs Backpack");
        }

        internal void ValidateBasketIsEmpty()
        {
            Helper.ValidateElementNotDisplayed(Map.CartItem);
        }
    }
}
