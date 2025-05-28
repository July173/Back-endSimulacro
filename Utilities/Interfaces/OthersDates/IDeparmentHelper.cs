namespace Utilities.Interfaces
{
    /// <summary>
    /// Proporciona utilidades y validaciones para la entidad Deparment.
    /// </summary>
    public interface IDepartmentHelper
    {
        /// <summary>
        /// Valida si el nombre del departamento es válido.
        /// </summary>
        bool IsValidDepartmentName(string name);

        /// <summary>
        /// Normaliza el nombre del departamento.
        /// </summary>
        string NormalizeDepartmentName(string name);

        /// <summary>
        /// Valida si la descripción del departamento es válida.
        /// </summary>
        bool IsValidDescription(string description);

        /// <summary>
        /// Normaliza la descripción del departamento.
        /// </summary>
        string NormalizeDescription(string description);

        /// <summary>
        /// Valida si el código del departamento es válido.
        /// </summary>
        bool IsValidDepartmentCode(string departmentCode);

        /// <summary>
        /// Valida si el identificador del país es válido.
        /// </summary>
        bool IsValidCountryId(int countryId);
    }
}
