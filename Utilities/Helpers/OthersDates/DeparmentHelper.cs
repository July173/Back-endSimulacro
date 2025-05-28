using System.Globalization;
using System.Text.RegularExpressions;
using Utilities.Interfaces;

namespace Utilities.Helpers
{
    /// <summary>
    /// Implementación de utilidades para la entidad Deparment.
    /// </summary>
    public class DepartmentHelper : IDepartmentHelper
    {
        public bool IsValidDepartmentName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && Regex.IsMatch(name, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ\-']+$")
                && name.Length >= 2
                && name.Length <= 100;
        }

        public string NormalizeDepartmentName(string name)
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

        public bool IsValidDepartmentCode(string departmentCode)
        {
            // Ejemplo: alfanumérico de 2 a 10 caracteres
            return !string.IsNullOrWhiteSpace(departmentCode)
                && Regex.IsMatch(departmentCode, @"^[A-Za-z0-9\-]{2,10}$");
        }

        public bool IsValidCountryId(int countryId)
        {
            return countryId > 0;
        }
    }
}
