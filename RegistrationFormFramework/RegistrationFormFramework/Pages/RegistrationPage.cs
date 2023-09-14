using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace RegistrationFormFramework.Pages
{
    public class RegistrationPage : BasePage
    {        
        public RegistrationPage(IWebDriver driver) : base(driver)
        {            
        }    
        
        private string errorMessageMask = $"//div[@id='errorMessages']/ul/li[text()='{{0}}']";

        private ReadOnlyCollection<IWebElement> RegisterAnAccountTitles => driver.FindElements(By.XPath("//h1[text()='Register an Account']"));
        private IWebElement UsernameField => driver.FindElement(By.Id("username"));
        private IWebElement PasswordField => driver.FindElement(By.Id("password1"));
        private IWebElement ConfirmPasswordField => driver.FindElement(By.Id("password2"));
        private IWebElement MaleRadiobutton => driver.FindElement(By.Id("genderM"));
        private IWebElement FemaleRadiobutton => driver.FindElement(By.Id("genderF"));
        private IWebElement DescribeYourselfTextArea => driver.FindElement(By.Id("desc"));
        private IWebElement YourContinentDropdown => driver.FindElement(By.Id("continent"));
        private IWebElement RegisterButton => driver.FindElement(By.Id("register"));        

        public void ChooseLocation(string continenet)
        {
            SelectElement selectContinent = new SelectElement(YourContinentDropdown);
            selectContinent.SelectByText(continenet);
        }

        public bool DropdownExistsAllContinents ()
        {
            List<string> continents = new List<string> { "Choose Your Continent", "Africa", "North America", "South America", "Antarctica", "Asia", "Australia", "Europe" };

            SelectElement selectContinent = new SelectElement(YourContinentDropdown);            
            
            List<string> actualContinents = new List<string>();
            foreach (IWebElement option in selectContinent.Options)
            {
                actualContinents.Add(option.Text);
            }

            return actualContinents.SequenceEqual(continents);              
        }

        public void FillUserData(string username, string password, string confirmPassword, string gender, string continent, string userInfo)
        {            
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            ConfirmPasswordField.SendKeys(confirmPassword);
            SelectGender(gender);
            ChooseLocation(continent);
            DescribeYourselfTextArea.SendKeys(userInfo);
            RegisterButton.Click();
        }

        public void SelectGender(string gender)
        {            
            switch (gender)
            {
                case "male":
                    MaleRadiobutton.Click(); 
                    break;
                case "female":
                    FemaleRadiobutton.Click();
                    break;
                case "":
                    break;
                default:
                    throw new ArgumentException("The corresponding radio button is missing: " + gender);
            }
        }

        public bool ErrorMessageIsDisplayed(string errorMessage)=>      
            driver.FindElement(By.XPath(string.Format(errorMessageMask, errorMessage))).Displayed;

        public bool RegisterAnAccountTitlePresent => RegisterAnAccountTitles.Count.Equals(1);
        public bool RegisterAnAccountTitleNotPresent => RegisterAnAccountTitles.Count.Equals(0);
    }
}