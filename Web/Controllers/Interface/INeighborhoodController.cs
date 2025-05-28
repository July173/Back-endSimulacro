using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolDTO;
using Entity.Model;
using Entity.DTOs.Person;
using Entity.Dtos.Base;
using Entity.Dtos.Neighborhood;

namespace Web.Controllers.Interface
{
    public interface INeighborhoodController : IGenericController<NeighborhoodDto, Neighborhood>
    {
        Task<IActionResult> UpdatePartial(NeighborhoodUpdateDto dto);
        Task<IActionResult> DeleteLogic(GenericDto dto);
    }
}


