using System.Globalization;
using System.Text.RegularExpressions;
using Utilities.Interfaces.OthersDates;

namespace Utilities.Helpers.OthersDates
{
    /// <summary>
    /// Implementación de utilidades para la entidad Provider.
    /// </summary>
    public class ProviderHelper : IProviderHelper
    {
        public bool IsValidProviderName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && Regex.IsMatch(name, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ\.\-']+$")
                && name.Length >= 2
                && name.Length <= 100;
        }

        public string NormalizeProviderName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            var trimmed = name.Trim();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(trimmed.ToLower());
        }

        public bool IsValidDescription(string description)
        {
            return string.IsNullOrWhiteSpace(description) || description.Length <= 250;
        }

        public string NormalizeDescription(string description)
        {
            return description?.Trim() ?? string.Empty;
        }

        public bool IsValidCompanyName(string companyName)
        {
            return !string.IsNullOrWhiteSpace(companyName)
                && companyName.Length >= 2
                && companyName.Length <= 150;
        }

        public bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email)
                && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public bool IsValidPhone(string phone)
        {
            return !string.IsNullOrWhiteSpace(phone)
                && Regex.IsMatch(phone, @"^\+?\d{7,15}$");
        }

        public bool IsValidDirection(string direction)
        {
            return !string.IsNullOrWhiteSpace(direction) && direction.Length <= 200;
        }

        public string NormalizeDirection(string direction)
        {
            return direction?.Trim() ?? string.Empty;
        }

        public bool IsValidUserId(int userId)
        {
            return userId > 0;
        }
    }
}
