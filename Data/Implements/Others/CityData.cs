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
    public class CityData : BaseModelData<City>, ICityData
    {
    public CityData(ApplicationDbContext context) :base(context) { }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var city = await _context.Set<City>().FindAsync(id);
            if (city == null)
                return false;

            city.Active = active;
            _context.Entry(city).Property(c => c.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(City city)
        {
            var existing = await _context.Cities.FindAsync(city.Id);
            if (existing == null)
                return false;
            _context.Cities.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
