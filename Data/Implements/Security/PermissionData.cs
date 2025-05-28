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
    public class PermissionData : BaseModelData<Permission>, IPermissionData
    {
        public PermissionData(ApplicationDbContext context) : base(context) { }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var permission = await _context.Set<Permission>().FindAsync(id);
            if (permission == null)
                return false;

            permission.Active = active;
            _context.Entry(permission).Property(p => p.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Permission permission)
        {
            var existing = await _context.Permissions.FindAsync(permission.Id);
            if (existing == null)
                return false;
            _context.Permissions.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
