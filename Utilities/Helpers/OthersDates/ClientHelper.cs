using System.Text.RegularExpressions;
using System.Globalization;
using Utilities.Interfaces;

namespace Utilities.Helpers
{
    /// <summary>
    /// Implementación de utilidades para la entidad Client.
    /// </summary>
    public class ClientHelper : IClientHelper
    {
        public bool IsValidClientName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && Regex.IsMatch(name, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ\.\-']+$")
                && name.Length >= 2
                && name.Length <= 100;
        }

        public string NormalizeClientName(string name)
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

        public bool IsValidPhone(string phone)
        {
            return !string.IsNullOrWhiteSpace(phone)
                && Regex.IsMatch(phone, @"^\+?\d{7,15}$");
        }

        public bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email)
                && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public bool IsValidAddress(string address)
        {
            return !string.IsNullOrWhiteSpace(address) && address.Length <= 200;
        }

        public string NormalizeAddress(string address)
        {
            return address?.Trim() ?? string.Empty;
        }

        public bool IsValidProviderId(int providerId)
        {
            return providerId > 0;
        }

        public bool IsValidUserId(int userId)
        {
            return userId > 0;
        }
    }
}
