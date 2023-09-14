using OpenQA.Selenium;

namespace RegistrationFormFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver driver = null;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;           
        } 
    }
}