namespace Utilities.Interfaces.Security
{
    /// <summary>
    /// Proporciona utilidades y validaciones para la entidad Person.
    /// </summary>
    public interface IPersonHelper
    {
        /// <summary>
        /// Valida si el nombre es válido.
        /// </summary>
        bool IsValidFirstName(string firstName);

        /// <summary>
        /// Valida si el segundo nombre es válido.
        /// </summary>
        bool IsValidSecondName(string secondName);

        /// <summary>
        /// Valida si el primer apellido es válido.
        /// </summary>
        bool IsValidFirstLastName(string firstLastName);

        /// <summary>
        /// Valida si el segundo apellido es válido.
        /// </summary>
        bool IsValidSecondLastName(string secondLastName);

        /// <summary>
        /// Normaliza un nombre o apellido.
        /// </summary>
        string NormalizeName(string name);

        /// <summary>
        /// Valida si la dirección es válida.
        /// </summary>
        bool IsValidDireccion(string direccion);

        /// <summary>
        /// Normaliza la dirección.
        /// </summary>
        string NormalizeDireccion(string direccion);

        /// <summary>
        /// Valida si el número de teléfono es válido.
        /// </summary>
        bool IsValidPhoneNumber(long phoneNumber);

        /// <summary>
        /// Valida si el tipo de identificación es válido.
        /// </summary>
        bool IsValidTypeIdentification(string typeIdentification);

        /// <summary>
        /// Valida si el número de identificación es válido.
        /// </summary>
        bool IsValidNumberIdentification(long numberIdentification);
    }
}
