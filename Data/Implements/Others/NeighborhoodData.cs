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
    public class NeighborhoodData : BaseModelData<Neighborhood>, INeighborhoodData
    {
        public NeighborhoodData(ApplicationDbContext context) : base(context) { }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var neighborhood = await _context.Set<Neighborhood>().FindAsync(id);
            if (neighborhood == null)
                return false;

            neighborhood.Active = active;
            _context.Entry(neighborhood).Property(n => n.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Neighborhood neighborhood)
        {
            var existing = await _context.Neighborhoods.FindAsync(neighborhood.Id);
            if (existing == null)
                return false;
            _context.Neighborhoods.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
