using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Utilities.Interfaces.OthersDates;

namespace Utilities.Helpers.OthersDates
{
    /// <summary>
    /// Implementación de utilidades para la entidad Employee.
    /// </summary>
    public class EmployeeHelper : IEmployeeHelper
    {
        public bool IsValidEmployeeName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && Regex.IsMatch(name, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ\.\-']+$")
                && name.Length >= 2
                && name.Length <= 100;
        }

        public string NormalizeEmployeeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            var trimmed = name.Trim();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(trimmed.ToLower());
        }

        public bool IsValidDescription(string description)
        {
            return string.IsNullOrWhiteSpace(description) || description.Length <= 250;
        }

        public string NormalizeDescription(string description)
        {
            return description?.Trim() ?? string.Empty;
        }

        public bool IsValidEmployeeCode(string employeeCode)
        {
            // Ejemplo: alfanumérico de 2 a 20 caracteres
            return !string.IsNullOrWhiteSpace(employeeCode)
                && Regex.IsMatch(employeeCode, @"^[A-Za-z0-9\-]{2,20}$");
        }

        public bool IsValidPosition(string position)
        {
            // Permite letras, espacios y algunos caracteres especiales
            return !string.IsNullOrWhiteSpace(position)
                && Regex.IsMatch(position, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ\.\-']+$")
                && position.Length >= 2
                && position.Length <= 100;
        }

        public bool IsValidDepartment(string department)
        {
            // Permite letras, espacios y algunos caracteres especiales
            return !string.IsNullOrWhiteSpace(department)
                && Regex.IsMatch(department, @"^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ\.\-']+$")
                && department.Length >= 2
                && department.Length <= 100;
        }

        public bool IsValidSalary(decimal salary)
        {
            // El salario debe ser mayor a cero
            return salary > 0;
        }

        public bool IsValidContractType(decimal contractType)
        {
            // Por ejemplo, debe ser mayor a cero (ajusta según tus reglas)
            return contractType > 0;
        }

        public bool IsValidWorkSchedule(decimal workSchedule)
        {
            // Por ejemplo, debe ser mayor a cero (ajusta según tus reglas)
            return workSchedule > 0;
        }

        public bool IsValidHireDate(DateTime hireDate)
        {
            // No puede ser en el futuro
            return hireDate <= DateTime.UtcNow;
        }

        public bool IsValidTerminationDate(DateTime hireDate, DateTime terminationDate)
        {
            // Puede ser nulo (DateTime.MinValue) o mayor/igual a la fecha de contratación
            return terminationDate == DateTime.MinValue || terminationDate >= hireDate;
        }

        public bool IsValidUserId(int userId)
        {
            return userId > 0;
        }
    }
}
