using Entity.Dtos.Base;
using Entity.Dtos.CountryDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers.Interface
{
    public interface ICountryController : IGenericController<CountryDto, Country>
    {
        Task<IActionResult> UpdatePartial(CountryUpdateDto dto);
        Task<IActionResult> DeleteLogic(GenericDto dto);
    }
}


