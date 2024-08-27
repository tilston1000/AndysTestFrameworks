using AndysTestFrameworks.DemoQA.PageObjects;
using AndysTestFrameworks.DemoQA.WebDriverFactory;
using OpenQA.Selenium;
using AndysTestFrameworks.DemoQA.WrapperFactory;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace AndysTestFrameworks.DemoQA.Tests.Base
{
    public class BaseTest
    {
        private IWebDriver Driver { get; set; }

        [SetUp]
        public void TestSetup()
        {
            var factory = new DriverFactory();
            Driver = factory.CreateBrowser(NetworkSelector.Local, BrowserType.Chrome);
            Pages.Init(Driver);
        }

        public static IConfigurationRoot ConfigureAppConfigFile()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appconfig.json")
                .Build();
        }

        public static void ConfigureApp()
        {
            var settings = ConfigureAppConfigFile();
            string url = settings["DEMOQAURL"];
        }

        [TearDown]
        public void TestEnding()
        {
            Driver.Close();
            Driver.Quit();
            Process.GetProcessesByName("chromedriver").ToList().ForEach(p => p.Kill());
        }
    }
}
