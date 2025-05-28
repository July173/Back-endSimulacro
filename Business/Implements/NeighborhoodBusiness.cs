using AutoMapper;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;
using Utilities.Interfaces;
using Entity.Model;
using Entity.Dtos.Neighborhood;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;


namespace Business.Implements.OthersDates
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad Neighborhood.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class NeighborhoodBusiness : BaseBusiness<Neighborhood, NeighborhoodDto>, INeighborhoodBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de barrios</summary>
        private readonly INeighborhoodData _neighborhoodData;

        /// <summary>
        /// Constructor de la clase NeighborhoodBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con barrios.
        /// </summary>
        public NeighborhoodBusiness(INeighborhoodData neighborhoodData, IMapper mapper, ILogger<NeighborhoodBusiness> logger, IGenericIHelpers helpers)
            : base(neighborhoodData, mapper, logger, helpers)
        {
            _neighborhoodData = neighborhoodData;
        }

        ///<summary>
        /// Actualiza parcialmente un barrio en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialAsync(NeighborhoodUpdateDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var neighborhood = _mapper.Map<Neighborhood>(dto);

            var result = await _neighborhoodData.UpdatePartial(neighborhood); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Cambia el estado activo/inactivo de un barrio en la base de datos (borrado lógico)
        /// </summary>
        public async Task<bool> ActiveAsync(GenericDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del barrio es inválido");

            var exists = await _neighborhoodData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("neighborhood", dto.Id);

            return await _neighborhoodData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
