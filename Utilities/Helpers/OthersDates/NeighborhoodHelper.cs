using System.Globalization;
using System.Text.RegularExpressions;
using Utilities.Interfaces.OthersDates;

namespace Utilities.Helpers.OthersDates
{
    /// <summary>
    /// Implementación de utilidades para la entidad Neighborhood.
    /// </summary>
    public class NeighborhoodHelper : INeighborhoodHelper
    {
        public bool IsValidNeighborhoodName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && Regex.IsMatch(name, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ\.\-']+$")
                && name.Length >= 2
                && name.Length <= 100;
        }

        public string NormalizeNeighborhoodName(string name)
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

        public bool IsValidCodePostal(string codePostal)
        {
            // Ejemplo: código postal de 4 a 10 caracteres alfanuméricos
            return !string.IsNullOrWhiteSpace(codePostal)
                && Regex.IsMatch(codePostal, @"^[a-zA-Z0-9\-]{4,10}$");
        }

        public bool IsValidDistrictName(string districtName)
        {
            return !string.IsNullOrWhiteSpace(districtName)
                && districtName.Length >= 2
                && districtName.Length <= 100;
        }

        public bool IsValidStreetNumber(string streetNumber)
        {
            return !string.IsNullOrWhiteSpace(streetNumber)
                && Regex.IsMatch(streetNumber, @"^[0-9]{1,6}$");
        }

        public bool IsValidSecondaryNumber(string secondaryNumber)
        {
            return string.IsNullOrWhiteSpace(secondaryNumber) || Regex.IsMatch(secondaryNumber, @"^[0-9]{1,6}$");
        }

        public bool IsValidTertiaryNumber(string tertiaryNumber)
        {
            return string.IsNullOrWhiteSpace(tertiaryNumber) || Regex.IsMatch(tertiaryNumber, @"^[0-9]{1,6}$");
        }

        public bool IsValidAdditionalNumber(string additionalNumber)
        {
            return string.IsNullOrWhiteSpace(additionalNumber) || Regex.IsMatch(additionalNumber, @"^[0-9]{1,6}$");
        }

        public bool IsValidCityId(int cityId)
        {
            return cityId > 0;
        }
    }
}
