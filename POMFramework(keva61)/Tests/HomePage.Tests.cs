using OpenQA.Selenium;
using POMFramework_keva61_.PageObjects;
using POMFramework_keva61_.Tests.Base;

namespace POMFramework_keva61_.Tests
{
    // Main test class

    [TestFixture]
    public class HomePageTests : BaseTest
    {
        [Test]
        [Description("Login Test")]
        [Author("Andy Tilston")]
        public void Valid_Login()
        {
            Pages.Home.GoTo();
            Pages.Home.Login();
            Pages.Inventory.Logout();

            Assert.IsTrue(Pages.Home.Map.LoginButton.Displayed);
        }

        [Test]
        [Description("Validate all items can be added to the cart")]
        [Author("Andy Tilston")]
        public void Add_All_Items_To_Cart()
        {
            Pages.Home.GoTo();
            Pages.Home.Login();
            Pages.Inventory.AddAllItemsToCart();

            Assert.IsTrue(Pages.Inventory.Map.ShoppingCart.Text == "6");
        }

    }
}
