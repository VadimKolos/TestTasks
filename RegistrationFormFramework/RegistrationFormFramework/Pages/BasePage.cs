using OpenQA.Selenium;

namespace RegistrationFormFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;           
        } 
    }
}