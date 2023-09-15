using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace RegistrationFormFramework.Core
{
    public static class BrowserFactory
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver(string browserType)
        {
            if (driver == null)
            {
                switch (browserType)
                {
                    case "Chrome":
                        driver = new ChromeDriver();
                        break;

                    case "Firefox":
                        driver = new FirefoxDriver();
                        break;

                    case "IE":
                        driver = new InternetExplorerDriver();
                        break;

                    default:
                        throw new ArgumentException("Invalid browser type specified.");
                }
            }
            driver.Manage().Window.Maximize();
            return driver;
        }           
    }   
}