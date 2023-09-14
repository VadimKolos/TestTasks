using NUnit.Framework;
using OpenQA.Selenium;
using RegistrationFormFramework.Core;

namespace RegistrationFormFramework.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver = null;        

        [SetUp]
        public virtual void TestSetUp()
        {            
            driver = BrowserFactory.GetDriver(TestContext.Parameters["BrowserType"]);  
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(TestContext.Parameters["TimeoutSeconds"]));
            driver.Navigate().GoToUrl(TestContext.Parameters["BaseUrl"]);
            driver.SwitchTo().Frame(0);            
        }

        [TearDown]
        public virtual void CleanTest()
        {
            driver.Quit();            
        }
    }
}