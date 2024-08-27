using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace AndysTestFrameworks.DemoQA.TestCases
{
    public class WaitCommandTestCases
    {

        IWebDriver _driver;
        string demoUrl = "https://demoqa.com/";
        string demoUrlAlertsWindow = "https://demoqa.com/alertsWindows";
        string automationPracticeFormUrl = "https://demoqa.com/automation-practice-form";

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            //_driver = new FirefoxDriver();
            //_driver = new InternetExplorerDriver();
        }

        [Test]
        public void BasicImplicitWaitTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _driver.Navigate().GoToUrl("https://demoqa.com/dynamic-properties");

            IWebElement element = _driver.FindElement(By.Id("visibleAfter"));
        }

        [Test]
        public void WebDriverWaitTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/dynamic-properties");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            Func<IWebDriver, IWebElement> waitForElement = new Func<IWebDriver, IWebElement>((Web) =>
            {
                Console.WriteLine("Waiting for colour to change");
                IWebElement element = Web.FindElement(By.Id("colorChange"));
                var buttonTextColor = element.GetCssValue("color");
                //var color = Color.(buttonTextColor);


                Debug.WriteLine("button color is " + buttonTextColor);

                if (element.GetCssValue("color").Contains("rgba(220, 53, 69, 1)"))
                {
                    return element;
                }
                return null;
            });

            IWebElement targetElement = wait.Until(waitForElement);
            Debug.WriteLine("Inner HTML of element is " + targetElement.GetAttribute("innerHTML"));
        }

        [Test]
        public void DefaultWaitTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/dynamic-properties");

            IWebElement element = _driver.FindElement(By.Id("colorChange"));
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromSeconds(5);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((ele) =>
            {
                var buttonTextColor = element.GetCssValue("color");
                if (buttonTextColor.Contains("rgba(220, 53, 69, 1)"))
                {
                    return true;
                }
                Debug.WriteLine("Color is still " + buttonTextColor);
                return false;
            });
            wait.Until(waiter);
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}
