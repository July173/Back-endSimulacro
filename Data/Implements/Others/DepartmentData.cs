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
    public class DepartmentData : BaseModelData<Department> , IDepartmentData

    {
        public DepartmentData(ApplicationDbContext context) : base(context) 
        {
        }
        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var department = await _context.Set<Department>().FindAsync(id);
            if (department == null)
                return false;

            department.Active = active;
            _context.Entry(department).Property(d => d.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Department department)
        {
            var existing = await _context.Departments.FindAsync(department.Id);
            if (existing == null)
                return false;
            _context.Departments.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
