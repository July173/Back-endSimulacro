using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implements.Security;
using Entity.Model;

namespace Data.Interfaces
{
    public interface IRolFormPermissionData : IBaseModelData<RolFormPermission>
    {
        Task<bool> UpdatePartial (RolFormPermission rolFormPermission);
    }
}
