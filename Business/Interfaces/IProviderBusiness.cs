using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.ProviderDto;
using Entity.Model;

namespace Business.Interfaces
{
    internal interface IProviderBusiness : IBaseBusiness<Provider, ProviderDto>
    {
        Task<bool> UpdatePartialAsync(ProvideUpdateDto dto);
        Task<bool> ActiveAsync(GenericDto dto);
    }
}
