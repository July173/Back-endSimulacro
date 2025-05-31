using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Dtos.Neighborhood;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements;

[Route("api/[controller]")]

public class NeighborhoodController : GenericController<NeighborhoodDto, Neighborhood>, INeighborhoodController
{
    private readonly INeighborhoodBusiness _neighborhoodBusiness;
    public NeighborhoodController(INeighborhoodBusiness neighborhoodBusiness, ILogger<NeighborhoodController> logger)
        : base(neighborhoodBusiness, logger)
    {
        _neighborhoodBusiness = neighborhoodBusiness;
    }
    protected override int GetEntityId(NeighborhoodDto dto)
    {
        return dto.Id;
    }

    [HttpPatch]
    public async Task<IActionResult> UpdatePartial(int id, int neighborhoodId, [FromBody] NeighborhoodUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _neighborhoodBusiness.UpdatePartialAsync(dto);
            return Ok(new { Success = result });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al actualizar parcialmente el barrio: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar parcialmente el barrio: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }


    [HttpDelete("logic/{id}")]
    public async Task<IActionResult> DeleteLogic(int id)
    {
        try
        {
            var dto = new GenericDto { Id = id, Active = false }; // Se inicializa la propiedad requerida 'Status'
            var result = await _neighborhoodBusiness.ActiveAsync(dto);
            if (!result)
                return NotFound($"Barrio con ID {id} no encontrado");
            return Ok(new { Success = true });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al eliminar lógicamente barrio: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar lógicamente el barrio con ID {id}: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
}