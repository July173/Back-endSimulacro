using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;

namespace Data.Interfaces
{
    public interface IPermissionData: IBaseModelData<Permission>
    {
        Task<bool> ActiveAsync(int id, bool active);
        Task<bool> UpdatePartial(Permission permission);
    }
}
