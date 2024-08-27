using OpenQA.Selenium;
using POMFramework_keva61_.PageObjects.Base;
using POMFramework_keva61_.PageObjects.Basket.Assertions;
using POMFramework_keva61_.PageObjects.Basket.Map;

namespace POMFramework_keva61_.PageObjects.Basket
{
    public class BasketPage : BasePage
    {
        public readonly BasketPageMap Map;
        public readonly BasketPageAssertions Assertions;

        public BasketPage(IWebDriver driver) : base(driver)
        {
            Map = new BasketPageMap(driver);
            Assertions = new BasketPageAssertions(driver);
        }

        public void RemoveItemFromBasketWhenOnlyOneItem()
        {
            Assertions.ValidateBasketHasOneItem();
            Map.RemoveButton.Click();
            Assertions.ValidateBasketIsEmpty();
        }

        public void ProceedToCheckout()
        {
            Map.CheckoutButton.Click();
        }
    }
}
