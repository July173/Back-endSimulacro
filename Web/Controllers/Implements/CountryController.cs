using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Dtos.CountryDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements;

[Route("api/[controller]")]
public class CountryController : GenericController<CountryDto, Country>, ICountryController
{
    private readonly ICountryBusiness _countryBusiness;
    public CountryController(ICountryBusiness countryBusiness, ILogger<CountryController> logger)
        : base(countryBusiness, logger)
    {
        _countryBusiness = countryBusiness;
    }

    protected override int GetEntityId(CountryDto dto)
    {
        return dto.Id;
    }

    [HttpPatch]

    public async Task<IActionResult> UpdatePartial(int id, int countryId, [FromBody] CountryUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _countryBusiness.UpdatePartialAsync(dto);
            return Ok(new { Success = result });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al actualizar parcialmente el país: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar parcialmente el país: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpDelete("logic/{id}")]

    public async Task<IActionResult> DeleteLogic(int id)
    {
        try
        {
            var dto = new GenericDto { Id = id, Active = false }; // Se inicializa la propiedad requerida 'Status'
            var result = await _countryBusiness.ActiveAsync(dto);
            if (!result)
                return NotFound($"País con ID {id} no encontrado");
            return Ok(new { Success = true });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al eliminar lógicamente país: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar lógicamente el país con ID {id}: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
}