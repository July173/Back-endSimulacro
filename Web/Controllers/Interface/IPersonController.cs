using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolDTO;
using Entity.Model;
using Entity.DTOs.Person;
using Entity.Dtos.Base;

namespace Web.Controllers.Interface
{
    public interface IPersonController : IGenericController<PersonDto, Person>
    {
        Task<IActionResult> UpdatePartial(UpdateRolDto dto);
        Task<IActionResult> DeleteLogic(GenericDto dto);
    }
}





