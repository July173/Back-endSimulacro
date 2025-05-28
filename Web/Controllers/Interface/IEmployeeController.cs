using Microsoft.AspNetCore.Mvc;
using Entity.Model;
using Entity.Dtos.Base;
using Entity.DTOs.Module;
using Entity.Dtos.EmployeeDto;

namespace Web.Controllers.Interface
{
    public interface IEmployeeController : IGenericController<EmployeeDto, Employee>
    {
        Task<IActionResult> UpdatePartial(EmployeeUpdateDto dto);
        Task<IActionResult> DeleteLogic(GenericDto dto);
    }
}


