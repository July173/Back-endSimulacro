using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.DTOs.Form;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements;

[Route("api/[controller]")]

public class FormController : GenericController<FormDto, Form>, IFormController
{
    private readonly IFormBusiness _formBusiness;
    public FormController(IFormBusiness formBusiness, ILogger<FormController> logger)
        : base(formBusiness, logger)
    {
        _formBusiness = formBusiness;
    }

    protected override int GetEntityId(FormDto dto)
    {
        return dto.Id;
    }

    [HttpPatch]

    public async Task<IActionResult> UpdatePartial(int id, int formId, [FromBody] FormUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _formBusiness.UpdatePartialAsync(dto);
            return Ok(new { Success = result });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al actualizar parcialmente el formulario: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar parcialmente el formulario: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpDelete("logic/{id}")]

    public async Task<IActionResult> DeleteLogic(int id)
    {
        try
        {
            var dto = new GenericDto { Id = id, Active = false }; // Se inicializa la propiedad requerida 'Status'
            var result = await _formBusiness.ActiveAsync(dto);
            if (!result)
                return NotFound($"Formulario con ID {id} no encontrado");
            return Ok(new { Success = true });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al eliminar lógicamente formulario: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar lógicamente el formulario con ID {id}: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
}