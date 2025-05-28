using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.EmployeeDto;
using Entity.DTOs.Form;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IEmployeeBusiness: IBaseBusiness<Employee,EmployeeDto>
    {
        Task<bool> UpdatePartialAsync(EmployeeUpdateDto dto);
        Task<bool> ActiveAsync(GenericDto dto);
    }
}
