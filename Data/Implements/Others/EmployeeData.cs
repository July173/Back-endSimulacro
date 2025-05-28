using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using FluentValidation.Validators;

namespace Data.Implements.Others
{
    public class EmployeeData : BaseModelData<Employee>, IEmployeeData
    {
        public EmployeeData(ApplicationDbContext context) : base(context) { }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var employee = await _context.Set<Rol>().FindAsync(id);
            if (employee == null)
                return false;

            employee.Active = active;
            _context.Entry( employee).Property(e => e.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Employee employee)
        {
            var existing = await _context.Employees.FindAsync(employee.Id);
            if (existing == null)
                return false;
            _context.Employees.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
