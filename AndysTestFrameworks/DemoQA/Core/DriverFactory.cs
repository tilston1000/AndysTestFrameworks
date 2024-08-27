using AndysTestFrameworks.DemoQA.WebDriverFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AndysTestFrameworks.DemoQA.WrapperFactory
{
    internal class DriverFactory
    {
        internal IWebDriver CreateBrowser(NetworkSelector type, BrowserType name)
        {
            return type switch
            {
                NetworkSelector.Local => (name switch
                {
                    BrowserType.Chrome => GetChromeDriver(),
                    BrowserType.Edge => GetEdgeDriver(),
                    BrowserType.Firefox => GetFirefoxDriver(),
                    _ => throw new ArgumentOutOfRangeException(name.ToString(), $"No such browser {name.ToString()}")
                }),
                NetworkSelector.Remote => CreateSauceDriver(),
                _ => throw new ArgumentOutOfRangeException(type.ToString(), $"Unknown Environment {type.ToString()}")
            };
        }

        private IWebDriver GetEdgeDriver()
        {
            return new EdgeDriver();
        }

        private IWebDriver CreateSauceDriver()
        {
            throw new NotImplementedException();
        }

        private IWebDriver GetFirefoxDriver()
        {
            return new FirefoxDriver();
        }

        private IWebDriver GetChromeDriver()
        {
            return new ChromeDriver();
        }
    }
}
