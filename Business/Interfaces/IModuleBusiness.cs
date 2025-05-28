using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.ProviderDto;
using Entity.DTOs.Module;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IModuleBusiness :IBaseBusiness<Module, ModuleDto>
    {
        Task<bool> UpdatePartialAsync(ModuleUpdateDto dto);
        Task<bool> ActiveAsync(GenericDto dto);
    }
}
