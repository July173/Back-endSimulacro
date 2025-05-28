namespace Utilities.Interfaces.OthersDates
{
    /// <summary>
    /// Proporciona utilidades y validaciones para la entidad Neighborhood.
    /// </summary>
    public interface INeighborhoodHelper
    {
        /// <summary>
        /// Valida si el nombre del barrio es válido.
        /// </summary>
        /// <param name="name">Nombre del barrio a validar.</param>
        /// <returns>True si el nombre es válido; False en caso contrario.</returns>
        bool IsValidNeighborhoodName(string name);

        /// <summary>
        /// Normaliza el nombre del barrio.
        /// </summary>
        /// <param name="name">Nombre del barrio a normalizar.</param>
        /// <returns>El nombre normalizado del barrio.</returns>
        string NormalizeNeighborhoodName(string name);

        /// <summary>
        /// Valida si la descripción del barrio es válida.
        /// </summary>
        /// <param name="description">Descripción a validar.</param>
        /// <returns>True si la descripción es válida; False en caso contrario.</returns>
        bool IsValidDescription(string description);

        /// <summary>
        /// Normaliza la descripción del barrio.
        /// </summary>
        /// <param name="description">Descripción a normalizar.</param>
        /// <returns>La descripción normalizada.</returns>
        string NormalizeDescription(string description);

        /// <summary>
        /// Valida si el código postal es válido.
        /// </summary>
        /// <param name="codePostal">Código postal a validar.</param>
        /// <returns>True si el código postal es válido; False en caso contrario.</returns>
        bool IsValidCodePostal(string codePostal);

        /// <summary>
        /// Valida si el nombre del distrito es válido.
        /// </summary>
        /// <param name="districtName">Nombre del distrito a validar.</param>
        /// <returns>True si el nombre es válido; False en caso contrario.</returns>
        bool IsValidDistrictName(string districtName);

        /// <summary>
        /// Valida si el número de calle es válido.
        /// </summary>
        /// <param name="streetNumber">Número de calle a validar.</param>
        /// <returns>True si el número es válido; False en caso contrario.</returns>
        bool IsValidStreetNumber(string streetNumber);

        /// <summary>
        /// Valida si el número secundario de calle es válido.
        /// </summary>
        /// <param name="secondaryNumber">Número secundario a validar.</param>
        /// <returns>True si el número es válido; False en caso contrario.</returns>
        bool IsValidSecondaryNumber(string secondaryNumber);

        /// <summary>
        /// Valida si el número terciario de calle es válido.
        /// </summary>
        /// <param name="tertiaryNumber">Número terciario a validar.</param>
        /// <returns>True si el número es válido; False en caso contrario.</returns>
        bool IsValidTertiaryNumber(string tertiaryNumber);

        /// <summary>
        /// Valida si el número adicional de calle es válido.
        /// </summary>
        /// <param name="additionalNumber">Número adicional a validar.</param>
        /// <returns>True si el número es válido; False en caso contrario.</returns>
        bool IsValidAdditionalNumber(string additionalNumber);

        /// <summary>
        /// Valida si el identificador de ciudad es válido.
        /// </summary>
        /// <param name="cityId">Identificador de ciudad a validar.</param>
        /// <returns>True si el identificador es válido; False en caso contrario.</returns>
        
    }
}
