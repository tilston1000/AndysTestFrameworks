using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace AndysTestFrameworks.DemoQA.TestCases
{
    public class DemoQATestCases
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
        public void FirstTestCase()
        {
            _driver.Navigate().GoToUrl(demoUrl);

            string title = _driver.Title;
            int titleLength = _driver.Title.Length;
            Debug.WriteLine("Title of the page is " + title);
            Debug.WriteLine("Length of the title is " + titleLength);

            string pageURL = _driver.Url;
            int urlLength = pageURL.Length;
            Debug.WriteLine("URL of the page is " + pageURL);
            Debug.WriteLine("Length of the URL is " + urlLength);

            string pageSource = _driver.PageSource;
            int pageSourceLength = pageSource.Length;
            Debug.WriteLine("Page source of the page is " + pageSource);
            Debug.WriteLine("Length of the page soruce is " + pageSourceLength);
        }

        [Test]
        public void ClickOnWindow()
        {
            _driver.Navigate().GoToUrl(demoUrlAlertsWindow);
            _driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[3]/div/ul/li[1]")).Click();
        }

        [Test]
        public void BrowserNavigation()
        {
            _driver.Navigate().GoToUrl(demoUrl);

            _driver.FindElement(By.XPath("//*[@class='category-cards']/div[4]")).Click();
            _driver.Navigate().Back();
            _driver.Navigate().Forward();
            _driver.Navigate().Refresh();
        }

        [Test]
        public void AutomationPracticeFormOne()
        {
            _driver.Navigate().GoToUrl(automationPracticeFormUrl);

            _driver.FindElement(By.Id("firstName")).SendKeys("Lakshay");
            _driver.FindElement(By.Id("lastName")).SendKeys("Sharma");
            _driver.FindElement(By.Id("submit")).Click();
        }

        [Test]
        public void FindElementByPartialLink()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/links");

            _driver.FindElement(By.PartialLinkText("Bad")).Click();
            Debug.WriteLine("Partial Link Test Pass");

            _driver.FindElement(By.LinkText("Unauthorized")).Click();
            Debug.WriteLine("Link Test Pass");

            _driver.Navigate().GoToUrl("https://demoqa.com/buttons");
            string sClass = _driver.FindElements(By.TagName("button")).ToString();
            Debug.WriteLine(sClass);
        }

        [Test]
        public void RadioButtonTestOnPracticeForm()
        {
            _driver.Navigate().GoToUrl(automationPracticeFormUrl);

            IList<IWebElement> radioButtonGender = _driver.FindElements(By.XPath("//*[@name='gender']"));
            bool bValue = false;
            bValue = radioButtonGender.ElementAt(0).Selected; //Male
            if (bValue == true)
            {
                radioButtonGender.ElementAt(1).Click(); // Female
            }
            else
            {
                radioButtonGender[1].Click();
            }

            IWebElement radioButtonOther = _driver.FindElement(By.Id("gender-radio-3"));
            radioButtonOther.Click();

            IWebElement hobbiesCheckBox = _driver.FindElement(By.CssSelector("input[value='1']"));
        }

        [Test]
        public void SelectMenuTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/select-menu");

            SelectElement colourSelection = new SelectElement(_driver.FindElement(By.Id("oldSelectMenu")));
            colourSelection.SelectByText("Yellow");
            Thread.Sleep(2000);
            colourSelection.SelectByIndex(2);

            IList<IWebElement> colourSelectionSize = colourSelection.Options;
            int iListSize = colourSelectionSize.Count;
            for (int i = 0; i < iListSize; i++)
            {
                string sValue = colourSelection.Options.ElementAt(i).Text;
                Debug.WriteLine("Value of the Select item is: " + sValue);

                if (sValue == "Indigo")
                {
                    colourSelection.SelectByIndex(i);
                    break;
                }
            }
        }

        [Test]
        public void MultiSelectTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/select-menu");

            SelectElement carSelect = new SelectElement(_driver.FindElement(By.Name("cars")));
            carSelect.SelectByIndex(0);
            Thread.Sleep(1000);
            carSelect.DeselectByIndex(0);

            carSelect.SelectByText("Saab");
            Thread.Sleep(1000);
            carSelect.DeselectByText("Saab");

            IList<IWebElement> carListSize = carSelect.Options;
            int iListSize = carListSize.Count;

            for (int i = 0; i < iListSize; i++)
            {
                string sValue = carSelect.Options.ElementAt(i).Text;
                Debug.WriteLine("Value of the item is : " + sValue);
                carSelect.SelectByIndex(i);

                Thread.Sleep(1000);
            }
            carSelect.DeselectAll();
        }

        [Test]
        public void TraverseThroughTable()
        {
            _driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Programming_languages_used_in_most_popular_websites");

            // xpath of html table
            var programmingLanguageTable = _driver.FindElement(By.XPath("//div[@id='mw-content-text']//table[1]"));
            // fetch all rows in the table
            List<IWebElement> allTableRows = new List<IWebElement>(programmingLanguageTable.FindElements(By.TagName("tr")));
            string rowData = "";
            // traverse through each row
            foreach (var elementRow in allTableRows)
            {
                // fetch the columns from a particular row
                List<IWebElement> lstTdElem = new List<IWebElement>(elementRow.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    // Traverse each column
                    foreach (var elemTd in lstTdElem)
                    {
                        // "\t\t" is used for Tab Space between two Text
                        rowData = rowData + elemTd.Text + "\t\t";
                    }
                }
                else
                {
                    // To print the data in the console
                    Debug.WriteLine("This is the Header Row");
                    Debug.WriteLine(allTableRows[0].Text.Replace(" ", "\t\t"));
                }
                Debug.WriteLine(rowData);
                rowData = string.Empty;
            }
            Debug.WriteLine("");
        }

        [Test]
        public void LocatorStrategies()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            // Locate by Id attribute
            _driver.FindElement(By.Id("firstName"));

            // Locate by Name attribute
            _driver.FindElement(By.Name("gender"));

            // Locate by Class Name attribute
            _driver.FindElement(By.ClassName("practice-form-wrapper"));

            // Locate by Link Text & Partial Link Text
            _driver.Navigate().GoToUrl("https://demoqa.com/links");
            _driver.FindElement(By.LinkText("Home"));
            _driver.FindElement(By.PartialLinkText("Ho"));

            // Locate by tagName attribute
            IList<IWebElement> list = _driver.FindElements(By.TagName("a"));
            Debug.WriteLine(list.Count);

            // Locate by css attribute
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            _driver.FindElement(By.CssSelector("input[id='userName']"));

            // Locate by xpath attribute
            _driver.FindElement(By.XPath("//input[@id='userName']"));
        }

        [TearDown]
        public void EndTest()
        {
            _driver.Close();
        }
    }
}