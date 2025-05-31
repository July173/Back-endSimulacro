using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolDTO;
using Entity.Model;
using Entity.DTOs.Person;
using Entity.Dtos.Base;
using Entity.DTOs;
using Entity.Dtos.PermissionDto;

namespace Web.Controllers.Interface
{
    public interface IPermissionController : IGenericController<PermissionDto, Permission>
    {
        Task<IActionResult> UpdatePartial(int id, int permissionId, PermissionUpdateDto dto);
        Task<IActionResult> DeleteLogic(int id );
    }
}


