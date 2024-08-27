using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace POMFramework_keva61_.Core
{
    // This class creates the webdriver object for the pages
    internal class Factory
    {
        internal IWebDriver CreateBrowser(NetworkSettings type, BrowserType name)
        {
            return type switch
            {
                NetworkSettings.Local => (name switch
                {
                    BrowserType.Chrome => GetChromeDriver(),
                    BrowserType.Edge => GetEdgeDriver(),
                    BrowserType.Firefox => GetFirefoxDriver(),
                    _ => throw new ArgumentOutOfRangeException(name.ToString(), $"No such browser {name.ToString()}")
                }),
                NetworkSettings.Remote => CreateSauceDriver(),
                _ => throw new ArgumentOutOfRangeException(type.ToString(), $"Unknown Environment {type.ToString()}")
            };
        }

        private IWebDriver CreateSauceDriver()
        {
            throw new NotImplementedException();
        }

        private IWebDriver GetFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--start-maximized");

            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver(options);
        }

        private IWebDriver GetEdgeDriver()
        {
            var options = new EdgeOptions();
            options.AddArgument("--start-maximized");

            new DriverManager().SetUpDriver(new EdgeConfig());
            return new EdgeDriver(options);
        }

        private IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }
    }
}