using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.ProviderDto;
using Entity.DTOs.Form;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IFormBusiness : IBaseBusiness<Form, FormDto>
    {
        Task<bool> UpdatePartialAsync(FormUpdateDto dto);
        Task<bool> ActiveAsync(GenericDto dto);
    }
}
