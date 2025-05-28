namespace Utilities.Interfaces.OthersDates
{
    /// <summary>
    /// Proporciona utilidades y validaciones para la entidad Provider.
    /// </summary>
    public interface IProviderHelper
    {
        /// <summary>
        /// Valida si el nombre del proveedor es válido.
        /// </summary>
        /// <param name="name">Nombre del proveedor a validar.</param>
        /// <returns>True si el nombre es válido; False en caso contrario.</returns>
        bool IsValidProviderName(string name);

        /// <summary>
        /// Normaliza el nombre del proveedor.
        /// </summary>
        /// <param name="name">Nombre del proveedor a normalizar.</param>
        /// <returns>El nombre normalizado del proveedor.</returns>
        string NormalizeProviderName(string name);

        /// <summary>
        /// Valida si la descripción del proveedor es válida.
        /// </summary>
        /// <param name="description">Descripción a validar.</param>
        /// <returns>True si la descripción es válida; False en caso contrario.</returns>
        bool IsValidDescription(string description);

        /// <summary>
        /// Normaliza la descripción del proveedor.
        /// </summary>
        /// <param name="description">Descripción a normalizar.</param>
        /// <returns>La descripción normalizada.</returns>
        string NormalizeDescription(string description);

        /// <summary>
        /// Valida si el nombre de la compañía es válido.
        /// </summary>
        /// <param name="companyName">Nombre de la compañía a validar.</param>
        /// <returns>True si el nombre es válido; False en caso contrario.</returns>
        bool IsValidCompanyName(string companyName);

        /// <summary>
        /// Valida si el correo electrónico es válido.
        /// </summary>
        /// <param name="email">Correo electrónico a validar.</param>
        /// <returns>True si el correo electrónico es válido; False en caso contrario.</returns>
        bool IsValidEmail(string email);

        /// <summary>
        /// Valida si el teléfono es válido.
        /// </summary>
        /// <param name="phone">Teléfono a validar.</param>
        /// <returns>True si el teléfono es válido; False en caso contrario.</returns>
        bool IsValidPhone(string phone);

        /// <summary>
        /// Valida si la dirección es válida.
        /// </summary>
        /// <param name="direction">Dirección a validar.</param>
        /// <returns>True si la dirección es válida; False en caso contrario.</returns>
        bool IsValidDirection(string direction);

        /// <summary>
        /// Normaliza la dirección.
        /// </summary>
        /// <param name="direction">Dirección a normalizar.</param>
        /// <returns>La dirección normalizada.</returns>
        string NormalizeDirection(string direction);

        /// <summary>
        /// Valida si el identificador de usuario es válido.
        /// </summary>
        /// <param name="userId">Identificador de usuario a validar.</param>
        /// <returns>True si el identificador es válido; False en caso contrario.</returns>
        bool IsValidUserId(int userId);
    }
}
