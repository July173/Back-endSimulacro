using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Data.Implements.RolData;
using Data.Interfaces;
using Entity.Dtos.Base;
using Entity.Dtos.ProviderDto;
using Entity.Dtos.RolDTO;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using Utilities.Interfaces;

namespace Business.Implements
{
    public class ProviderBusiness : BaseBusiness<Provider, ProviderDto>, IProviderBusiness
    {
        private readonly IProviderData _providerData;

        public ProviderBusiness(IProviderData providerData, IMapper mapper, ILogger<ProviderBusiness> logger, IGenericIHelpers helpers)
        : base(providerData, mapper, logger, helpers)
        {
            _providerData = providerData;
        }

       
        public async Task<bool> UpdatePartialAsync(ProvideUpdateDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");


            var provider = _mapper.Map<Provider>(dto);

            var result = await _providerData.UpdatePartial(provider); // esto ya retorna bool
            return result;
        }

        public async Task<bool> ActiveAsync(GenericDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del provider es inválido");

            var exists = await _providerData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("provider", dto.Id);

            return await _providerData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
