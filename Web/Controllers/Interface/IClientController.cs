using Microsoft.AspNetCore.Mvc;
using Entity.Model;
using Entity.Dtos.Base;
using Entity.Dtos.ClientDto;


namespace Web.Controllers.Interface
{
    public interface IClientController : IGenericController<ClientDto, Client>
    {
        Task<IActionResult> UpdatePartial(int id, int clientId, ClientUpdateDto dto);
        Task<IActionResult> DeleteLogic(int id);
    }
}


