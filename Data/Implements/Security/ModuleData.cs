﻿using System;
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
    public class ModuleData : BaseModelData<Module>, IModuleData
    {
        public ModuleData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var module = await _context.Set<Module>().FindAsync(id);
            if (module == null)
                return false;
            module.Active = active;
            _context.Entry(module).Property(m => m.Active).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Module module)
        {
            var existing = await _context.Modules.FindAsync(module.Id);
            if (existing == null)
                return false;
            _context.Modules.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
 
}
