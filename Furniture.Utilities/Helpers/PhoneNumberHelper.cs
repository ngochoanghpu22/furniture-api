using System.Text.RegularExpressions;

namespace Furniture.Utilities.Helpers
{
    public static class PhoneNumberHelper
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            var pattern = @"^[0-9]{10,15}$";
            Regex rgx = new Regex(pattern);

            var isValid = rgx.IsMatch(phoneNumber);
            return isValid;
        }
    }
}
