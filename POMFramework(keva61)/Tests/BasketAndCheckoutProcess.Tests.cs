using POMFramework_keva61_.PageObjects;
using POMFramework_keva61_.Tests.Base;

namespace POMFramework_keva61_.Tests
{
    [TestFixture]
    public class BasketAndCheckoutProcess : BaseTest
    {
        [Test]
        [Description("Ensure minicart updates when items are added and removed")]
        [Author("Andy Tilston")]
        public void Minicart_Updates()
        {
            Pages.Home.GoTo();
            Pages.Home.Login();
            Pages.Inventory.AddItemToCart();
            Pages.Inventory.AddItemTwoToCart();
            Pages.Inventory.RemoveItemTwoFromCart();
            Pages.Inventory.RemoveItemOneFromCart();
        }

        [Test]
        [Description("Validate that items can be removed from the basket")]
        [Author("Andy Tilston")]
        public void RemovingItemsFromBasket()
        {
            Pages.Home.GoTo();
            Pages.Home.Login();
            Pages.Inventory.AddItemToCart();
            Pages.Inventory.NavigateToCheckout();
            Pages.Basket.RemoveItemFromBasketWhenOnlyOneItem();
        }

        [Test]
        [Description("Checkout test")]
        [Author("Andy Tilston")]
        public void Buy_Most_Expensive_Item()
        {
            Pages.Home.GoTo();
            Pages.Home.Login();
            Pages.Inventory.SortByMostExpensive();
            Pages.Inventory.AddItemToCart();
            Pages.Inventory.Checkout();
            Pages.Basket.ProceedToCheckout();
            Pages.Checkout.EnterDetails("Example", "User", "A123");
            Pages.Checkout.FinishCheckout();

            Assert.IsTrue(Pages.Checkout.Map.PonyExpressImage.Displayed);
        }

        [Test]
        [Description("Add an item to basket, logout and back in, and ensure items are persisted")]
        [Author("Andy Tilston")]
        public void Add_Item_And_Log_Out_And_Then_Back_In_And_Ensure_Item_Persisted()
        {
            Pages.Home.GoTo();
            Pages.Home.Login();
            Pages.Inventory.AddItemToCart();
            Pages.Inventory.Logout();
            Pages.Home.Login();

            Assert.IsTrue(Pages.Inventory.Map.ShoppingCart.Text == "1");
        }

        [Test]
        [Description("Checks to ensure that all functions are operational on checkout page")]
        [Author("Andy Tilston")]
        public void Checkout_Functional_Checks()
        {
            Pages.Home.GoTo();
            Pages.Home.Login();
            Pages.Inventory.SortByMostExpensive();
            Pages.Inventory.AddItemToCart();
            Pages.Inventory.Checkout();
            Pages.Basket.ProceedToCheckout();
        }
    }
}
