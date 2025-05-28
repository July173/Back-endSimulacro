using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.DepartmentDto;
using Entity.DTOs.Form;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IDepartmentBusiness : IBaseBusiness<Department, DepartmentDto>
    {
        Task<bool> UpdatePartialAsync(DepartmentUpdateDto dto);
        Task<bool> ActiveAsync(GenericDto dto);
    }
}
