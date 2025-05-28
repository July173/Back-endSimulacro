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
    public class ClientData :BaseModelData<Client>, IClientData
    {
        public ClientData(ApplicationDbContext context): base(context)
        {

        }
        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var client = await _context.Set<Client>().FindAsync(id);
            if (client == null)
                return false;

            client.Active = active;
            _context.Entry(client).Property(c => c.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Client client)
        {
            var existing = await _context.Clients.FindAsync(client.Id);
            if (existing == null)
                return false;
            _context.Clients.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
