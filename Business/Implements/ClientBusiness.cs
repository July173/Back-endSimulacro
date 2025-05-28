using AutoMapper;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;
using Utilities.Interfaces;
using Entity.Model;
using Entity.Dtos.ClientDto;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.Base;


namespace Business.Implements.OthersDates
{
    /// <summary>
    /// Contiene la lógica de negocio de los métodos específicos para la entidad Client.
    /// Extiende BaseBusiness heredando la lógica de negocio de los métodos base.
    /// </summary>
    public class ClientBusiness : BaseBusiness<Client, ClientDto>, IClientBusiness
    {
        ///<summary>Proporciona acceso a los métodos de la capa de datos de clientes</summary>
        private readonly IClientData _clientData;

        /// <summary>
        /// Constructor de la clase ClientBusiness
        /// Inicializa una nueva instancia con las dependencias necesarias para operar con clientes.
        /// </summary>
        public ClientBusiness(IClientData clientData, IMapper mapper, ILogger<ClientBusiness> logger, IGenericIHelpers helpers)
            : base(clientData, mapper, logger, helpers)
        {
            _clientData = clientData;
        }

        ///<summary>
        /// Actualiza parcialmente un cliente en la base de datos
        /// </summary>
        public async Task<bool> UpdatePartialAsync(ClientUpdateDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var client = _mapper.Map<Client>(dto);

            var result = await _clientData.UpdatePartial(client); // esto ya retorna bool
            return result;
        }

        ///<summary>
        /// Cambia el estado activo/inactivo de un cliente en la base de datos (borrado lógico)
        /// </summary>
        public async Task<bool> ActiveAsync(GenericDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del cliente es inválido");

            var exists = await _clientData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("client", dto.Id);

            return await _clientData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
