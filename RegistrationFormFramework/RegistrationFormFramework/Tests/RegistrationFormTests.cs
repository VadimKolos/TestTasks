using RegistrationFormFramework.Pages;
using NUnit.Framework;
using RegistrationFormFramework.Core;

namespace RegistrationFormFramework.Tests
{
    public class RegistrationFormTests : BaseTest
    {
        [TestCase(4, "123", "123", "male", "Europe", "User info")]
        [TestCase(100, "123", "123", "male", "Europe", "User info")]
        public void CheckLoginTest(int usernameLength, string password, string confirmPassword, string gender, string continent, string userInfo)
        {            
            string username = StringGenerator.GenerateRandomStringWithSpecialChar(usernameLength);

            RegistrationPage registrationPage = new RegistrationPage(driver);
            Assert.IsTrue(registrationPage.RegisterAnAccountTitlePresent);
            Assert.IsTrue(registrationPage.DropdownExistsAllContinents());
            registrationPage.FillUserData(username, password, confirmPassword, gender, continent, userInfo);

            Assert.IsTrue(registrationPage.RegisterAnAccountTitleNotPresent);
        }

        [TestCase("", "123", "123", "male", "Europe", "User info", "* Please enter Username")]
        [TestCase("user", "", "123", "male", "Europe", "User info", "* Please enter Password1")]
        [TestCase("user", "123", "", "male", "Europe", "User info", "* Please enter Password2")]
        [TestCase("user", "123", "123", "male", "Choose Your Continent", "User info", "* Please select your location")]
        [TestCase("user", "123", "123", "male", "Europe", "", "* Please enter a description about you")]
        [TestCase("user", "123", "000", "male", "Europe", "User info", "* Passwords do not match")]
        [TestCase("user", "123", "123", "", "Europe", "User info", "* Please choose your gender")]
        public void CheckRegistrationWithEmptyFieldsTest(string username, string password, string confirmPassword, string gender, string continent, string userInfo, string errorMessage)
        {
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.FillUserData(username, password, confirmPassword, gender, continent, userInfo);
            Assert.IsTrue(registrationPage.ErrorMessageIsDisplayed(errorMessage));
        }
    }
}