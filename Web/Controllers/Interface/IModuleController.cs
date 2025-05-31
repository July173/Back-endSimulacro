using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolDTO;
using Entity.Model;
using Entity.DTOs.Person;
using Entity.Dtos.Base;
using Entity.DTOs;
using Entity.DTOs.Module;

namespace Web.Controllers.Interface
{
    public interface IModuleController : IGenericController<ModuleDto, Module>
    {
        Task<IActionResult> UpdatePartial(int id, int moduleId, ModuleUpdateDto dto);
        Task<IActionResult> DeleteLogic(int id );
    }
}


