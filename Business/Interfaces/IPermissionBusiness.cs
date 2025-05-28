using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.PermissionDto;
using Entity.Dtos.ProviderDto;
using Entity.DTOs;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IPermissionBusiness : IBaseBusiness<Permission, PermissionDto>
    {
        Task<bool> UpdatePartialAsync(PermissionUpdateDto dto);
        Task<bool> ActiveAsync(GenericDto dto);
    }
}
