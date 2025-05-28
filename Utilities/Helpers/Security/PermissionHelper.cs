using System.Globalization;
using System.Text.RegularExpressions;
using Entity.Enums;
using Utilities.Interfaces.Security;

namespace Utilities.Helpers.Security
{
    /// <summary>
    /// Implementación de utilidades para la entidad Permission.
    /// </summary>
    public class PermissionHelper : IPermissionHelper
    {
        public bool IsValidPermissionName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && Regex.IsMatch(name, @"^[a-zA-Z0-9\sáéíóúÁÉÍÓÚñÑ\.\-']+$")
                && name.Length >= 2
                && name.Length <= 100;
        }

        public string NormalizePermissionName(string name)
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

        public bool IsValidPermissionType(PermissionType type)
        {
            // Valida que el tipo esté dentro del rango definido en el enum
            return System.Enum.IsDefined(typeof(PermissionType), type);
        }
    }
}
