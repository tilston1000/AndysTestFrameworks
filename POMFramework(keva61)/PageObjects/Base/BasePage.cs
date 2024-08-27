using OpenQA.Selenium;
using POMFramework_keva61_.Utilities;

namespace POMFramework_keva61_.PageObjects.Base
{
    public class BasePage
    {
        protected Helpers Helper { get; }

        protected BasePage(IWebDriver driver)
        {
            Helper = new Helpers(driver);
        }
    }
}
