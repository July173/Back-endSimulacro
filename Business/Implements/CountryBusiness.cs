using AutoMapper;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;
using Utilities.Interfaces;
using Entity.Model;
using Entity.Dtos.CountryDto;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;


namespace Business.Implements.OthersDates
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad Country.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class CountryBusiness : BaseBusiness<Country, CountryDto>, ICountryBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de países</summary>
        private readonly ICountryData _countryData;

        /// <summary>
        /// Constructor de la clase CountryBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con países.
        /// </summary>
        public CountryBusiness(ICountryData countryData, IMapper mapper, ILogger<CountryBusiness> logger, IGenericIHelpers helpers)
            : base(countryData, mapper, logger, helpers)
        {
            _countryData = countryData;
        }

        ///<summary>
        /// Actualiza parcialmente un país en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialAsync(CountryUpdateDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var country = _mapper.Map<Country>(dto);

            var result = await _countryData.UpdatePartial(country); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Cambia el estado activo/inactivo de un país en la base de datos (borrado lógico)
        /// </summary>
        public async Task<bool> ActiveAsync(GenericDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del país es inválido");

            var exists = await _countryData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("country", dto.Id);

            return await _countryData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
