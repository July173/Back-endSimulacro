using AutoMapper;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;
using Utilities.Interfaces;
using Entity.Model;
using Entity.DTOs.Form;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;


namespace Business.Implements.Security
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad Form.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class FormBusiness : BaseBusiness<Form, FormDto>, IFormBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de formularios</summary>
        private readonly IFormData _formData;

        /// <summary>
        /// Constructor de la clase FormBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con formularios.
        /// </summary>
        public FormBusiness(IFormData formData, IMapper mapper, ILogger<FormBusiness> logger, IGenericIHelpers helpers)
            : base(formData, mapper, logger, helpers)
        {
            _formData = formData;
        }

        ///<summary>
        /// Actualiza parcialmente un formulario en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialAsync(FormUpdateDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var form = _mapper.Map<Form>(dto);

            var result = await _formData.UpdatePartial(form); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Cambia el estado activo/inactivo de un formulario en la base de datos (borrado lógico)
        /// </summary>
        public async Task<bool> ActiveAsync(GenericDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del formulario es inválido");

            var exists = await _formData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("form", dto.Id);

            return await _formData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
