using System.Globalization;
using System.Text.RegularExpressions;
using Utilities.Interfaces;

namespace Utilities.Helpers
{
    /// <summary>
    /// Implementación de utilidades para la entidad City.
    /// </summary>
    public class CityHelper : ICityHelper
    {
        public bool IsValidCityName(string name)
        {
            // Ejemplo: solo letras, espacios y longitud mínima
            return !string.IsNullOrWhiteSpace(name)
                && Regex.IsMatch(name, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ\-']+$")
                && name.Length >= 2
                && name.Length <= 100;
        }

        public string NormalizeCityName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            var trimmed = name.Trim();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(trimmed.ToLower());
        }

        public bool IsValidDescription(string description)
        {
            // Permite nulo o vacío, o hasta 250 caracteres
            return string.IsNullOrWhiteSpace(description) || description.Length <= 250;
        }

        public string NormalizeDescription(string description)
        {
            return description?.Trim() ?? string.Empty;
        }

        public bool IsValidDeparmentId(int deparmentId)
        {
            // Debe ser mayor a cero
            return deparmentId > 0;
        }
    }
}
