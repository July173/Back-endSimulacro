using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.DTOs.Person;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements;

[Route("api/[controller]")]

public class PersonController : GenericController<PersonDto, Person>, IPersonController
{
    private readonly IPersonBusiness _personBusiness;

    public PersonController(IPersonBusiness personBusiness, ILogger<PersonController> logger)
        : base(personBusiness, logger)
    {
        _personBusiness = personBusiness;
    }
    protected override int GetEntityId(PersonDto dto)
    {
        return dto.Id;

    }
    [HttpPatch]
    public async Task<IActionResult> UpdatePartial(int id, int personId, [FromBody] PersonUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _personBusiness.UpdatePartialAsync(dto);
            return Ok(new { Success = result });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al actualizar parcialmente persona: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar parcialmente persona: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpDelete("logic/{id}")]
    public async Task<IActionResult> DeleteLogic(int id)
    {
        try
        {
            var dto = new GenericDto { Id = id, Active = false }; // Se inicializa la propiedad requerida 'Status'
            var result = await _personBusiness.ActiveAsync(dto);
            if (!result)
                return NotFound($"person con ID {id} no encontrado");
            return Ok(new { Success = true });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al eliminar lógicamente person: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar lógicamente person con ID {id}: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

}