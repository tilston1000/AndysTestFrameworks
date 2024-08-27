using OpenQA.Selenium;
using POMFramework_keva61_.Core;
using POMFramework_keva61_.PageObjects;
using System.Diagnostics;

namespace POMFramework_keva61_.Tests.Base
{
    public class BaseTest
    {
        private IWebDriver Driver { get; set; }

        [SetUp]
        public void TestSetup()
        {
            var factory = new Factory();
            Driver = factory.CreateBrowser(NetworkSettings.Local, BrowserType.Chrome);
            Pages.Init(Driver);
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