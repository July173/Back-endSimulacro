namespace Utilities.Interfaces.OthersDates
{
    /// <summary>
    /// Proporciona utilidades y validaciones para la entidad Module.
    /// </summary>
    public interface IModuleHelper
    {
        /// <summary>
        /// Valida si el nombre del módulo es válido.
        /// </summary>
        bool IsValidModuleName(string name);

        /// <summary>
        /// Normaliza el nombre del módulo.
        /// </summary>
        string NormalizeModuleName(string name);

        /// <summary>
        /// Valida si la descripción del módulo es válida.
        /// </summary>
        bool IsValidDescription(string description);

        /// <summary>
        /// Normaliza la descripción del módulo.
        /// </summary>
        string NormalizeDescription(string description);

        /// <summary>
        /// Valida si el código del módulo es válido.
        /// </summary>
        bool IsValidModuleCode(string moduleCode);

        /// <summary>
        /// Valida si el identificador de usuario es válido.
        /// </summary>
        bool IsValidUserId(int userId);
    }
}
