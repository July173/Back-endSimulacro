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
    public class FormData : BaseModelData<Form>, IFormData
    {
        public FormData(ApplicationDbContext context) : base(context) { }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var form = await _context.Set<Form>().FindAsync(id);
            if (form == null)
                return false;

            form.Active = active;
            _context.Entry( form).Property(f => f.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Form form)
        {
            var existing = await _context.Forms.FindAsync(form.Id);
            if (existing == null)
                return false;
            _context.Forms.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
