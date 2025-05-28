using Entity.Enums;

namespace Utilities.Interfaces.Security
{
    /// <summary>
    /// Proporciona utilidades y validaciones para la entidad Permission.
    /// </summary>
    public interface IPermissionHelper
    {
        /// <summary>
        /// Valida si el nombre del permiso es válido.
        /// </summary>
        bool IsValidPermissionName(string name);

        /// <summary>
        /// Normaliza el nombre del permiso.
        /// </summary>
        string NormalizePermissionName(string name);

        /// <summary>
        /// Valida si la descripción del permiso es válida.
        /// </summary>
        bool IsValidDescription(string description);

        /// <summary>
        /// Normaliza la descripción del permiso.
        /// </summary>
        string NormalizeDescription(string description);

        /// <summary>
        /// Valida si el tipo de permiso es válido.
        /// </summary>
        bool IsValidPermissionType(PermissionType type);
    }
}
