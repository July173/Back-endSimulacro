using Microsoft.AspNetCore.Mvc;
using Entity.Model;
using Entity.Dtos.Base;
using Entity.Dtos.DepartmentDto;

namespace Web.Controllers.Interface
{
    public interface IDepartmentController : IGenericController<DepartmentDto, Department>
    {
        Task<IActionResult> UpdatePartial(DepartmentUpdateDto dto);
        Task<IActionResult> DeleteLogic(GenericDto dto);
    }
}


