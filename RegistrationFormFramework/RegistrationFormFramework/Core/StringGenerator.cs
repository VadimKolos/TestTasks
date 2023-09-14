using System.Text;

namespace RegistrationFormFramework.Core
{
    public static class StringGenerator
    {
        private const string DefaultChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const string SpecialChars = "!@#$%^&*()_+-=[]{}|;':,.<>? ";

        public static string GenerateRandomStringWithSpecialChar(int length)
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder(length);

            int specialCharIndex = random.Next(SpecialChars.Length);
            char specialChar = SpecialChars[specialCharIndex];
            stringBuilder.Append(specialChar);

            for (int i = 0; i < length; i++)
            {
                int charIndex = random.Next(DefaultChars.Length);
                char randomChar = DefaultChars[charIndex];
                stringBuilder.Append(randomChar);
            }

            return stringBuilder.ToString();
        }
    }
}