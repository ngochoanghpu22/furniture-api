using System.Text.RegularExpressions;

namespace Furniture.Utilities.Helpers
{
    public static class RegexHelper
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            var pattern = @"^[0-9]{10,15}$";
            Regex rgx = new Regex(pattern);

            var isValid = rgx.IsMatch(phoneNumber);
            return isValid;
        }

        public static bool IsValidEmail(string email)
        {
            var pattern = @"[a-zA-Z0-9.-_]{1,}@[a-zA-Z.-]{2,}[.]{1}[a-zA-Z]{2,}";
            Regex rgx = new Regex(pattern);

            var isValid = rgx.IsMatch(email);
            return isValid;
        }
    }
}
