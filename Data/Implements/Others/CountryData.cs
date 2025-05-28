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
    public class CountryData : BaseModelData<Country>, ICountryData
    {
        public CountryData(ApplicationDbContext context) :base(context)
        {

        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var country = await _context.Set<Country>().FindAsync(id);
            if (country == null)
                return false;

            country.Active = active;
            _context.Entry(country).Property(c => c.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Country country)
        {
            var existing = await _context.Countries.FindAsync(country.Id);
            if (existing == null)
                return false;
            _context.Countries.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
