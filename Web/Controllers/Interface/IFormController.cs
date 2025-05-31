using Microsoft.AspNetCore.Mvc;
using Entity.Model;
using Entity.Dtos.Base;
using Entity.DTOs;
using Entity.DTOs.Module;
using Entity.DTOs.Form;

namespace Web.Controllers.Interface
{
    public interface IFormController : IGenericController<FormDto, Form>
    {
        Task<IActionResult> UpdatePartial(int id, int formId, FormUpdateDto dto);
        Task<IActionResult> DeleteLogic(int id);
    }
}


