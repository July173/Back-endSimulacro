using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;

namespace Data.Implements.Others
{
    public class ProviderData :BaseModelData<Provider>, IProviderData
    {
        public ProviderData (ApplicationDbContext context) : base(context)
        {

        }
        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var provider = await _context.Set<Provider>().FindAsync(id);
            if (provider == null)
                return false;

            provider.Active = active;
            _context.Entry(provider).Property(p => p.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Provider provider)
        {
            var existing = await _context.Providers.FindAsync(provider.Id);
            if (existing == null)
                return false;
            _context.Providers.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
