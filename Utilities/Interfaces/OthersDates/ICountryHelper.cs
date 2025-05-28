namespace Utilities.Interfaces
{
    /// <summary>
    /// Proporciona utilidades y validaciones para la entidad Country.
    /// </summary>
    public interface ICountryHelper
    {
        /// <summary>
        /// Valida si el nombre del país es válido.
        /// </summary>
        bool IsValidCountryName(string name);

        /// <summary>
        /// Normaliza el nombre del país.
        /// </summary>
        string NormalizeCountryName(string name);

        /// <summary>
        /// Valida si la descripción del país es válida.
        /// </summary>
        bool IsValidDescription(string description);

        /// <summary>
        /// Normaliza la descripción del país.
        /// </summary>
        string NormalizeDescription(string description);

        /// <summary>
        /// Valida si el código del país es válido (por ejemplo, ISO 3166-1 alfa-2 o alfa-3).
        /// </summary>
        bool IsValidCountryCode(string countryCode);
    }
}
