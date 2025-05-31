using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolDTO;
using Entity.Model;
using Entity.DTOs.Person;
using Entity.Dtos.Base;

namespace Web.Controllers.Interface
{
    public interface IPersonController : IGenericController<PersonDto, Person>
    {
        Task<IActionResult> UpdatePartial(int id, int personId, PersonUpdateDto dto);
        Task<IActionResult> DeleteLogic( int id);
    }
}