using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.DTOs.FormModule;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Interfaces;

namespace Business.Implements
{
    public class FormModuleBusiness : BaseBusiness<FormModule, FormModuleDto>, IFormModuleBusiness
    {
        private readonly IFormModuleData _formModuleData;

        public FormModuleBusiness(IFormModuleData formModuleData, IMapper mapper, ILogger<FormModuleBusiness> logger, IGenericIHelpers helpers)
            : base(formModuleData, mapper, logger, helpers)
        {
            _formModuleData = formModuleData;
        }

        public async Task<bool> UpdatePartialAsync(FormModuleDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var formModule = _mapper.Map<FormModule>(dto);
            var result = await _formModuleData.UpdatePartial(formModule);
            return result;
        }
    }
}
