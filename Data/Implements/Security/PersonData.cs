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
    public class PersonData : BaseModelData<Person> , IPersonData
    {
        public PersonData(ApplicationDbContext context) : base(context) { }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var person = await _context.Set<Person>().FindAsync(id);
            if (person == null) 
                return false;
            person.Active = active;
            _context.Entry(person).Property(p => p.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePartial(Person person)
        {
            var existing = await _context.Persons.FindAsync(person.Id);
            if (existing == null)
                return false;
            _context.Persons.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
