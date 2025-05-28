using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolDTO;
using Entity.Model;
using Entity.Dtos.ProviderDto;
using Entity.Dtos.Base;

namespace Web.Controllers.Interface
{
    public interface IProviderController : IGenericController<ProviderDto, Provider>
    {
        Task<IActionResult> UpdatePartial( ProvideUpdateDto dto);
        Task<IActionResult> DeleteLogic(GenericDto dto);
    }
}