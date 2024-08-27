using AndysTestFrameworks.DemoQA.Utilities;
using OpenQA.Selenium;

namespace AndysTestFrameworks.DemoQA.PageObjects.Base
{
    public class BasePage
    {
        protected Helpers Helpers { get; set; }
        protected BasePage(IWebDriver driver)
        {
            Helpers = new Helpers(driver);
        }

    }
}
