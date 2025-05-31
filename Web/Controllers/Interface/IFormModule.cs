
using Microsoft.AspNetCore.Mvc;
using Entity.Model;
using Web.Controllers.Interface;
using Entity.DTOs.FormModule;

namespace Web.Controllers.Interface
{
    public interface IFormModuleController : IGenericController<FormModuleDto, FormModule>
    {
        Task<IActionResult> UpdatePartial(int id, int formModule, FormModuleDto dto);
    }
}