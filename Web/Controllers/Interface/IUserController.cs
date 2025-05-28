using Entity.Dtos.Base;
using Entity.Dtos.UserDTO;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IUserController : IGenericController<UserDto, User>
    {
        Task<IActionResult> GetUserByEmail(string email);
        Task<IActionResult> UpdatePartialUser(UserUpdateDto dto);
        Task<IActionResult> SetUserActive( GenericDto dto);
       
    }
}