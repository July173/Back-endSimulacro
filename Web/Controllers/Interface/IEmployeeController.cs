using Microsoft.AspNetCore.Mvc;
using Entity.Model;
using Entity.Dtos.Base;
using Entity.DTOs.Module;
using Entity.Dtos.EmployeeDto;

namespace Web.Controllers.Interface
{
    public interface IEmployeeController : IGenericController<EmployeeDto, Employee>
    {
        Task<IActionResult> UpdatePartial(int id, int roleId, EmployeeUpdateDto dto);
        Task<IActionResult> DeleteLogic(int id);
    }
}


