using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.ProviderDto;
using Entity.DTOs.FormModule;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IFormModuleBusiness : IBaseBusiness<FormModule, FormModuleDto >
    {
        Task<bool> UpdatePartialAsync(FormModuleDto dto);
    }
}
