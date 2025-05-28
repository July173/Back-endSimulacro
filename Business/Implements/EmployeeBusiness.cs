using AutoMapper;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;
using Utilities.Interfaces;
using Entity.Model;
using Entity.Dtos.EmployeeDto;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;


namespace Business.Implements.OthersDates
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad Employee.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class EmployeeBusiness : BaseBusiness<Employee, EmployeeDto>, IEmployeeBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de empleados</summary>
        private readonly IEmployeeData _employeeData;

        /// <summary>
        /// Constructor de la clase EmployeeBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con empleados.
        /// </summary>
        public EmployeeBusiness(IEmployeeData employeeData, IMapper mapper, ILogger<EmployeeBusiness> logger, IGenericIHelpers helpers)
            : base(employeeData, mapper, logger, helpers)
        {
            _employeeData = employeeData;
        }

        ///<summary>
        /// Actualiza parcialmente un empleado en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialAsync(EmployeeUpdateDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var employee = _mapper.Map<Employee>(dto);

            var result = await _employeeData.UpdatePartial(employee); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Cambia el estado activo/inactivo de un empleado en la base de datos (borrado lógico)
        /// </summary>
        public async Task<bool> ActiveAsync(GenericDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del empleado es inválido");

            var exists = await _employeeData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("employee", dto.Id);

            return await _employeeData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
