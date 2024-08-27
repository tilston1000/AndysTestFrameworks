using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace AndysTestFrameworks.DemoQA.TestCases
{
    public class AlertsFramesWindowsAndTabsTestCases
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void OpenJavaScriptAlert()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/alerts");

            var alertButton = _driver.FindElement(By.Id("alertButton"));
            alertButton.Click();
            var alert = _driver.SwitchTo().Alert();
            var expectedAlertText = "You clicked a button";
            Assert.That(alert.Text, Is.EqualTo(expectedAlertText));
            alert.Accept();
        }

        [Test]
        public void DismissConfirmationAlert()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/alerts");

            var alertButton = _driver.FindElement(By.Id("confirmButton"));
            alertButton.Click();
            var alert = _driver.SwitchTo().Alert();
            var expectedAlertText = "Do you confirm action?";
            Assert.That(alert.Text, Is.EqualTo(expectedAlertText));
            alert.Dismiss();
        }

        [Test]
        public void HandlingPromptAlerts()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/alerts");

            var promptButton = _driver.FindElement(By.Id("promtButton"));
            // 'IJavaScriptExecutor' is an 'interface' which is used to run the 'JavaScript code' into the webdriver (Browser)        
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click()", promptButton);
            var promptAlert = _driver.SwitchTo().Alert();
            var promptAlertText = promptAlert.Text;
            Debug.WriteLine("Alert text is: " + promptAlertText);
            promptAlert.SendKeys("Accepting the alert");
            promptAlert.Accept();

            var promptResult = _driver.FindElement(By.Id("promptResult"));
            Debug.WriteLine("Prompt Result Text is: " + promptResult.Text);
            var expectedPromptResultText = "You entered Accepting the alert";
            Assert.AreEqual(expectedPromptResultText, promptResult.Text);
        }

        [Test]
        public void OpenNewBrowserWindow()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            var newBrowserWindowButton = _driver.FindElement(By.Id("windowButton"));
            Assert.That(_driver.WindowHandles.Count, Is.EqualTo(1));

            string originalWindowTitle = "DEMOQA";
            Assert.AreEqual(originalWindowTitle, _driver.Title);

            newBrowserWindowButton.Click();
            Assert.AreEqual(2, _driver.WindowHandles.Count);
            string newWindowHandle = _driver.WindowHandles.Last();
            var newWindow = _driver.SwitchTo().Window(newWindowHandle);
            var newWindowUrl = _driver.Url;
            string expectedNewWindowUrl = "https://demoqa.com/sample";
            Assert.AreEqual(expectedNewWindowUrl, newWindowUrl);

        }

        [Test]
        public void OpenBrowserTab()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            var newTabButton = _driver.FindElement(By.Id("tabButton"));
            string originalTabTitle = "DEMOQA";
            Assert.AreEqual(originalTabTitle, _driver.Title);

            newTabButton.Click();
            var newTabHandle = _driver.WindowHandles.Last();
            var newTab = _driver.SwitchTo().Window(newTabHandle);

            var expectedNewTabUrl = "https://demoqa.com/sample";
            Assert.AreEqual(expectedNewTabUrl, newTab.Url);

            var originalTab = _driver.SwitchTo().Window(_driver.WindowHandles.First());
            Assert.AreEqual(originalTabTitle, originalTab.Title);
        }

        [Test]
        public void ObtainingWindowHandles()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            // Store the parent window of the driver
            var parentWindowHandle = _driver.CurrentWindowHandle;
            Debug.WriteLine("Parent window's handle: " + parentWindowHandle);

            IWebElement newWindowButton = _driver.FindElement(By.Id("windowButton"));

            // Multiple clicks to open multiple windows
            for (var i = 0; i < 3; i++)
            {
                newWindowButton.Click();
                Thread.Sleep(2000); // this is just for demo purposes!
            }

            // Store all the opened windows in the list
            // Print each item in the list
            List<string> listOfWindows = _driver.WindowHandles.ToList();
            foreach (var windowHandle in listOfWindows)
            {
                Debug.WriteLine(windowHandle);
            }
        }

        [Test]
        public void SwitchingToMultipleWindowHandlesAndThenClosingAllWindows()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            // Store the parent window of the driver
            var parentWindowHandle = _driver.CurrentWindowHandle;
            Debug.WriteLine("Parent window's handle: " + parentWindowHandle);

            IWebElement newWindowButton = _driver.FindElement(By.Id("windowButton"));

            // Multiple clicks to open multiple windows
            for (var i = 0; i < 3; i++)
            {
                newWindowButton.Click();
                Thread.Sleep(2000); // this is just for demo purposes!
            }

            // Store all of the opened windows in a list
            List<string> listOfWindows = _driver.WindowHandles.ToList();

            // Traverse through each of the windows
            foreach (var windowHandle in listOfWindows)
            {
                Debug.WriteLine("Switching to window: " + windowHandle);
                Debug.WriteLine("Navigating to google.com");

                // Switch to the desired window first and then execute commands using the driver
                _driver.SwitchTo().Window(windowHandle);
                _driver.Navigate().GoToUrl("https://google.com");
            }

            foreach (var windowHandle in listOfWindows)
            {
                _driver.SwitchTo().Window(windowHandle);
                _driver.Close();
            }
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                _driver.Close();
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine("Session is already closed. Exception is: " + ex);
            }
        }

    }
}
