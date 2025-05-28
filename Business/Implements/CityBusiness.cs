using AutoMapper;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;
using Utilities.Interfaces;
using Entity.Model;
using Entity.Dtos.CityDto;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;


namespace Business.Implements.OthersDates
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad City.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class CityBusiness : BaseBusiness<City, CityDto>, ICityBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de ciudades</summary>
        private readonly ICityData _cityData;

        /// <summary>
        /// Constructor de la clase CityBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con ciudades.
        /// </summary>
        public CityBusiness(ICityData cityData, IMapper mapper, ILogger<CityBusiness> logger, IGenericIHelpers helpers)
            : base(cityData, mapper, logger, helpers)
        {
            _cityData = cityData;
        }

        ///<summary>
        /// Actualiza parcialmente una ciudad en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialAsync(CityUpdateDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var city = _mapper.Map<City>(dto);

            var result = await _cityData.UpdatePartial(city); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Cambia el estado activo/inactivo de una ciudad en la base de datos (borrado lógico)
        /// </summary>
        public async Task<bool> ActiveAsync(GenericDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID de la ciudad es inválido");

            var exists = await _cityData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("city", dto.Id);

            return await _cityData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
