using System.Text.RegularExpressions;

namespace Furniture.Utilities.Helpers
{
    public static class EmailHelper
    {
        public static bool IsValidEmail(string email)
        {
            var pattern = @"[a-zA-Z0-9.-_]{1,}@[a-zA-Z.-]{2,}[.]{1}[a-zA-Z]{2,}";
            Regex rgx = new Regex(pattern);

            var isValid = rgx.IsMatch(email);
            return isValid;
        }
    }
}
