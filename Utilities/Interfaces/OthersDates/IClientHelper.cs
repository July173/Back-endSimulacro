namespace Utilities.Interfaces
{
    /// <summary>
    /// Proporciona utilidades y validaciones para la entidad Client.
    /// </summary>
    public interface IClientHelper
    {
        /// <summary>
        /// Valida si el nombre del cliente es válido.
        /// </summary>
        /// <param name="name">Nombre del cliente a validar.</param>
        /// <returns>
        /// True si el nombre es válido; False en caso contrario.
        /// </returns>
        bool IsValidClientName(string name);

        /// <summary>
        /// Normaliza el nombre del cliente (por ejemplo, elimina espacios y aplica formato de mayúsculas).
        /// </summary>
        /// <param name="name">Nombre del cliente a normalizar.</param>
        /// <returns>
        /// El nombre normalizado del cliente.
        /// </returns>
        string NormalizeClientName(string name);

        /// <summary>
        /// Valida si la descripción del cliente es válida.
        /// </summary>
        /// <param name="description">Descripción a validar.</param>
        /// <returns>
        /// True si la descripción es válida; False en caso contrario.
        /// </returns>
        bool IsValidDescription(string description);

        /// <summary>
        /// Normaliza la descripción del cliente.
        /// </summary>
        /// <param name="description">Descripción a normalizar.</param>
        /// <returns>
        /// La descripción normalizada.</returns>
        string NormalizeDescription(string description);

        /// <summary>
        /// Valida si el número de teléfono del cliente es válido.
        /// </summary>
        /// <param name="phone">Número de teléfono a validar.</param>
        /// <returns>
        /// True si el número de teléfono es válido; False en caso contrario.
        /// </returns>
        bool IsValidPhone(string phone);

        /// <summary>
        /// Valida si el correo electrónico del cliente es válido.
        /// </summary>
        /// <param name="email">Correo electrónico a validar.</param>
        /// <returns>
        /// True si el correo electrónico es válido; False en caso contrario.
        /// </returns>
        bool IsValidEmail(string email);

        /// <summary>
        /// Valida si la dirección del cliente es válida.
        /// </summary>
        /// <param name="address">Dirección a validar.</param>
        /// <returns>
        /// True si la dirección es válida; False en caso contrario.
        /// </returns>
        bool IsValidAddress(string address);

        /// <summary>
        /// Normaliza la dirección del cliente.
        /// </summary>
        /// <param name="address">Dirección a normalizar.</param>
        /// <returns>
        /// La dirección normalizada.</returns>
        string NormalizeAddress(string address);

        /// <summary>
        /// Valida si el identificador del proveedor es válido.
        /// </summary>
        /// <param name="providerId">Identificador del proveedor a validar.</param>
        /// <returns>
        /// True si el identificador es válido; False en caso contrario.
        /// </returns>
        bool IsValidProviderId(int providerId);

        /// <summary>
        /// Valida si el identificador del usuario es válido.
        /// </summary>
        /// <param name="userId">Identificador del usuario a validar.</param>
        /// <returns>
        /// True si el identificador es válido; False en caso contrario.
        /// </returns>
        bool IsValidUserId(int userId);
    }
}
