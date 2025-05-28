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
    public class FormModuleData : BaseModelData<FormModule>, IFormModuleData 
    {
        public FormModuleData (ApplicationDbContext context) : base (context)
        {

        }
        public async Task<bool> UpdatePartial (FormModule formModule)
        {
            var existing = await _context.FormModules.FindAsync(formModule.Id);
            if (existing == null) return false;
            // Update only the fields that are not null
            _context.FormModules.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}