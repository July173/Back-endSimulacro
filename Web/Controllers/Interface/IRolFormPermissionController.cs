
using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolUserDTO;
using Entity.Model;
using Web.Controllers.Interface;
using Entity.DTOs;

namespace Web.Controllers.Interface
{
    public interface IRolFormPermissionController : IGenericController<RolFormPermissionDto, RolFormPermission>
    {
        Task<IActionResult> UpdatePartial(RolFormPermissionDto dto);
    }
}