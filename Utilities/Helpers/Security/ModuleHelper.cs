using System.Globalization;
using System.Text.RegularExpressions;
using Utilities.Interfaces.OthersDates;
using Utilities.Interfaces.Security;

namespace Utilities.Helpers.OthersDates
{
    /// <summary>
    /// Implementación de utilidades para la entidad Module.
    /// </summary>
    public class ModuleHelper : IModuleHelper
    {
        public bool IsValidModuleName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && Regex.IsMatch(name, @"^[a-zA-Z0-9\sáéíóúÁÉÍÓÚñÑ\.\-']+$")
                && name.Length >= 2
                && name.Length <= 100;
        }

        public string NormalizeModuleName(string name)
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

        public bool IsValidModuleCode(string moduleCode)
        {
            // Ejemplo: alfanumérico de 2 a 20 caracteres
            return !string.IsNullOrWhiteSpace(moduleCode)
                && Regex.IsMatch(moduleCode, @"^[A-Za-z0-9\-]{2,20}$");
        }

        public bool IsValidUserId(int userId)
        {
            return userId > 0;
        }
    }
}
