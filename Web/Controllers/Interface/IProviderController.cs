using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.RolDTO;
using Entity.Model;
using Entity.Dtos.ProviderDto;
using Entity.Dtos.Base;

namespace Web.Controllers.Interface
{
    public interface IProviderController : IGenericController<ProviderDto, Provider>
    {
        Task<IActionResult> UpdatePartial(int id, int providerId, ProvideUpdateDto dto);
        Task<IActionResult> DeleteLogic(int id);
    }
}