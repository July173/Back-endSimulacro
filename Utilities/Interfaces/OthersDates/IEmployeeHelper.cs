using System;

namespace Utilities.Interfaces.OthersDates
{
    /// <summary>
    /// Proporciona utilidades y validaciones para la entidad Employee.
    /// </summary>
    public interface IEmployeeHelper
    {
        /// <summary>
        /// Valida si el nombre del empleado es válido.
        /// </summary>
        bool IsValidEmployeeName(string name);

        /// <summary>
        /// Normaliza el nombre del empleado.
        /// </summary>
        string NormalizeEmployeeName(string name);

        /// <summary>
        /// Valida si la descripción del empleado es válida.
        /// </summary>
        bool IsValidDescription(string description);

        /// <summary>
        /// Normaliza la descripción del empleado.
        /// </summary>
        string NormalizeDescription(string description);

        /// <summary>
        /// Valida si el código del empleado es válido.
        /// </summary>
        bool IsValidEmployeeCode(string employeeCode);

        /// <summary>
        /// Valida si el puesto del empleado es válido.
        /// </summary>
        bool IsValidPosition(string position);

        /// <summary>
        /// Valida si el departamento del empleado es válido.
        /// </summary>
        bool IsValidDepartment(string department);

        /// <summary>
        /// Valida si el salario es válido.
        /// </summary>
        bool IsValidSalary(decimal salary);

        /// <summary>
        /// Valida si el tipo de contrato es válido.
        /// </summary>
        bool IsValidContractType(decimal contractType);

        /// <summary>
        /// Valida si el horario de trabajo es válido.
        /// </summary>
        bool IsValidWorkSchedule(decimal workSchedule);

        /// <summary>
        /// Valida si la fecha de contratación es válida.
        /// </summary>
        bool IsValidHireDate(DateTime hireDate);

        /// <summary>
        /// Valida si la fecha de terminación es válida.
        /// </summary>
        bool IsValidTerminationDate(DateTime hireDate, DateTime terminationDate);

        /// <summary>
        /// Valida si el identificador de usuario es válido.
        /// </summary>
        bool IsValidUserId(int userId);
    }
}
