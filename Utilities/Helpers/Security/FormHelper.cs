using System.Globalization;
using System.Text.RegularExpressions;
using Utilities.Interfaces.OthersDates;

namespace Utilities.Helpers.OthersDates
{
    /// <summary>
    /// Implementación de utilidades para la entidad Form.
    /// </summary>
    public class FormHelper : IFormHelper
    {
        public bool IsValidFormName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && Regex.IsMatch(name, @"^[a-zA-Z0-9\sáéíóúÁÉÍÓÚñÑ\.\-']+$")
                && name.Length >= 2
                && name.Length <= 100;
        }

        public string NormalizeFormName(string name)
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

        public bool IsValidFormCode(string formCode)
        {
            // Ejemplo: alfanumérico de 2 a 20 caracteres
            return !string.IsNullOrWhiteSpace(formCode)
                && Regex.IsMatch(formCode, @"^[A-Za-z0-9\-]{2,20}$");
        }

        public bool IsValidUserId(int userId)
        {
            return userId > 0;
        }
    }
}
