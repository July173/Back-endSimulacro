using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IRolFormPermissionBusiness : IBaseBusiness<RolFormPermission,RolFormPermissionDto >
    {
        Task<bool> UpdatePartialAsync(RolFormPermissionDto dto);
    }
}
