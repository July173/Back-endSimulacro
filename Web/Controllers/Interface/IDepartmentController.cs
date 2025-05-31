using Microsoft.AspNetCore.Mvc;
using Entity.Model;
using Entity.Dtos.Base;
using Entity.Dtos.DepartmentDto;

namespace Web.Controllers.Interface
{
    public interface IDepartmentController : IGenericController<DepartmentDto, Department>
    {
        Task<IActionResult> UpdatePartial(int id, int departmentId, DepartmentUpdateDto dto);
        Task<IActionResult> DeleteLogic(int id);
    }
}


