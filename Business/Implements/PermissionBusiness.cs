using AutoMapper;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;
using Utilities.Interfaces;
using Entity.Model;
using Entity.DTOs;
using Data.Interfaces;
using Entity.Dtos.PermissionDto;
using Entity.Dtos.Base;


namespace Business.Implements.Security
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad Permission.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class PermissionBusiness : BaseBusiness<Permission, PermissionDto>, IPermissionBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de permisos</summary>
        private readonly IPermissionData _permissionData;

        /// <summary>
        /// Constructor de la clase PermissionBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con permisos.
        /// </summary>
        public PermissionBusiness(IPermissionData permissionData, IMapper mapper, ILogger<PermissionBusiness> logger, IGenericIHelpers helpers)
            : base(permissionData, mapper, logger, helpers)
        {
            _permissionData = permissionData;
        }

        ///<summary>
        /// Actualiza parcialmente un permiso en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialAsync(PermissionUpdateDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var permission = _mapper.Map<Permission>(dto);

            var result = await _permissionData.UpdatePartial(permission); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Cambia el estado activo/inactivo de un permiso en la base de datos (borrado lógico)
        /// </summary>
        public async Task<bool> ActiveAsync(GenericDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del permiso es inválido");

            var exists = await _permissionData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("permission", dto.Id);

            return await _permissionData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
