using Microsoft.AspNetCore.Mvc;
using Entity.Model;
using Entity.Dtos.Base;
using Entity.Dtos.CityDto;

namespace Web.Controllers.Interface
{
    public interface ICityController : IGenericController<CityDto, City>
    {
        Task<IActionResult> UpdatePartial(CityUpdateDto dto);
        Task<IActionResult> DeleteLogic(GenericDto dto);
    }
}


