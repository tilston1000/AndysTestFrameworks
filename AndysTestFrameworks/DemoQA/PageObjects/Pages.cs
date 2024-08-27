using AndysTestFrameworks.DemoQA.PageObjects.Login;
using AndysTestFrameworks.DemoQA.Tests.Base;
using AndysTestFrameworks.DemoQA.WrapperFactory;
using OpenQA.Selenium;

namespace AndysTestFrameworks.DemoQA.PageObjects
{
    public class Pages : BaseTest
    {
        static IWebDriver driver;  

        // This class is utilised by giving all of the page objects values when the initialise method is called prior to the tests execution. When this occurs, they can be referenced in the tests.

        public static LoginPage Login;

        public static void Init(IWebDriver driver)
        {
            Login = new LoginPage(driver);
        }
    }
}
