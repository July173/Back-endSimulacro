using System.Globalization;
using System.Text.RegularExpressions;
using Utilities.Interfaces;

namespace Utilities.Helpers
{
    /// <summary>
    /// Implementación de utilidades para la entidad Country.
    /// </summary>
    public class CountryHelper : ICountryHelper
    {
        public bool IsValidCountryName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && Regex.IsMatch(name, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ\-']+$")
                && name.Length >= 2
                && name.Length <= 100;
        }

        public string NormalizeCountryName(string name)
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

        public bool IsValidCountryCode(string countryCode)
        {
            // ISO 3166-1 alfa-2 o alfa-3: dos o tres letras
            return !string.IsNullOrWhiteSpace(countryCode)
                && Regex.IsMatch(countryCode, @"^[A-Za-z]{2,3}$");
        }
    }
}
