namespace Utilities.Interfaces
{
    /// <summary>
    /// Proporciona utilidades y validaciones para la entidad City.
    /// </summary>
    public interface ICityHelper
    {
        /// <summary>
        /// Valida si el nombre de la ciudad es válido.
        /// </summary>
        bool IsValidCityName(string name);

        /// <summary>
        /// Normaliza el nombre de la ciudad.
        /// </summary>
        string NormalizeCityName(string name);

        /// <summary>
        /// Valida si la descripción de la ciudad es válida.
        /// </summary>
        bool IsValidDescription(string description);

        /// <summary>
        /// Normaliza la descripción de la ciudad.
        /// </summary>
        string NormalizeDescription(string description);

        /// <summary>
        /// Valida si el identificador de departamento es válido.
        /// </summary>
        bool IsValidDeparmentId(int deparmentId);
    }
}
