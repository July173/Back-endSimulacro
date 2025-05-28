using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;

namespace Data.Implements.Security
{
    public class RolFormPermissionData : BaseModelData<RolFormPermission>, IRolFormPermissionData
    {
        public RolFormPermissionData(ApplicationDbContext context) : base(context) { }

        public async Task<bool> UpdatePartial(RolFormPermission rolFormPermission)
        {
            var existing = await _context.RolFormPermissions.FindAsync(rolFormPermission.Id);
            if (existing == null) return false;
            _context.RolFormPermissions.Update(existing);
            await _context.SaveChangesAsync();
            return true;    

        }
    }
}
