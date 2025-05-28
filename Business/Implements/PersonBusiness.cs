using AutoMapper;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;
using Utilities.Interfaces;
using Entity.Model;
using Entity.DTOs.Person;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;


namespace Business.Implements.Security
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad Person.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class PersonBusiness : BaseBusiness<Person, PersonDto>, IPersonBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de personas</summary>
        private readonly IPersonData _personData;

        /// <summary>
        /// Constructor de la clase PersonBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con personas.
        /// </summary>
        public PersonBusiness(IPersonData personData, IMapper mapper, ILogger<PersonBusiness> logger, IGenericIHelpers helpers)
            : base(personData, mapper, logger, helpers)
        {
            _personData = personData;
        }

        ///<summary>
        /// Actualiza parcialmente una persona en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialAsync(PersonUpdateDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var person = _mapper.Map<Person>(dto);

            var result = await _personData.UpdatePartial(person); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Cambia el estado activo/inactivo de una persona en la base de datos (borrado lógico)
        /// </summary>
        public async Task<bool> ActiveAsync(GenericDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID de la persona es inválido");

            var exists = await _personData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("person", dto.Id);

            return await _personData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
