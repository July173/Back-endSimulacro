using System.Globalization;
using System.Text.RegularExpressions;
using Utilities.Interfaces.Security;

namespace Utilities.Helpers.Security
{
    /// <summary>
    /// Implementación de utilidades para la entidad Person.
    /// </summary>
    public class PersonHelper : IPersonHelper
    {
        public bool IsValidFirstName(string firstName)
        {
            return !string.IsNullOrWhiteSpace(firstName)
                && Regex.IsMatch(firstName, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-']+$")
                && firstName.Length >= 2
                && firstName.Length <= 50;
        }

        public bool IsValidSecondName(string secondName)
        {
            // Puede ser vacío o cumplir las mismas reglas que el primer nombre
            return string.IsNullOrWhiteSpace(secondName) || IsValidFirstName(secondName);
        }

        public bool IsValidFirstLastName(string firstLastName)
        {
            return !string.IsNullOrWhiteSpace(firstLastName)
                && Regex.IsMatch(firstLastName, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-']+$")
                && firstLastName.Length >= 2
                && firstLastName.Length <= 50;
        }

        public bool IsValidSecondLastName(string secondLastName)
        {
            // Puede ser vacío o cumplir las mismas reglas que el primer apellido
            return string.IsNullOrWhiteSpace(secondLastName) || IsValidFirstLastName(secondLastName);
        }

        public string NormalizeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            var trimmed = name.Trim();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(trimmed.ToLower());
        }

        public bool IsValidDireccion(string direccion)
        {
            return !string.IsNullOrWhiteSpace(direccion) && direccion.Length <= 200;
        }

        public string NormalizeDireccion(string direccion)
        {
            return direccion?.Trim() ?? string.Empty;
        }

        public bool IsValidPhoneNumber(long phoneNumber)
        {
            // Ejemplo: debe tener entre 7 y 15 dígitos
            var phoneStr = phoneNumber.ToString();
            return phoneNumber > 0 && phoneStr.Length >= 7 && phoneStr.Length <= 15;
        }

        public bool IsValidTypeIdentification(string typeIdentification)
        {
            // Ejemplo: solo letras y longitud razonable
            return !string.IsNullOrWhiteSpace(typeIdentification)
                && Regex.IsMatch(typeIdentification, @"^[a-zA-Z\s\-]+$")
                && typeIdentification.Length >= 2
                && typeIdentification.Length <= 20;
        }

        public bool IsValidNumberIdentification(long numberIdentification)
        {
            // Ejemplo: debe ser positivo y tener entre 6 y 20 dígitos
            var idStr = numberIdentification.ToString();
            return numberIdentification > 0 && idStr.Length >= 6 && idStr.Length <= 20;
        }
    }
}
