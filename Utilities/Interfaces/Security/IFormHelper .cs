namespace Utilities.Interfaces.OthersDates
{
    /// <summary>
    /// Proporciona utilidades y validaciones para la entidad Form.
    /// </summary>
    public interface IFormHelper
    {
        /// <summary>
        /// Valida si el nombre del formulario es válido.
        /// </summary>
        bool IsValidFormName(string name);

        /// <summary>
        /// Normaliza el nombre del formulario.
        /// </summary>
        string NormalizeFormName(string name);

        /// <summary>
        /// Valida si la descripción del formulario es válida.
        /// </summary>
        bool IsValidDescription(string description);

        /// <summary>
        /// Normaliza la descripción del formulario.
        /// </summary>
        string NormalizeDescription(string description);

        /// <summary>
        /// Valida si el código del formulario es válido.
        /// </summary>
        bool IsValidFormCode(string formCode);

        /// <summary>
        /// Valida si el identificador de usuario es válido.
        /// </summary>
        bool IsValidUserId(int userId);
    }
}
