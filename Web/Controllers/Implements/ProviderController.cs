using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Dtos.ProviderDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements;

[Route("api/[controller]")]

public class ProviderController : GenericController<ProviderDto, Provider> , IProviderController
{
    private readonly IProviderBusiness _providerBusiness;

    public ProviderController(IProviderBusiness providerBusiness, ILogger<ProviderController> logger)
        : base(providerBusiness, logger)
    {
        _providerBusiness = providerBusiness;
    }
    protected override int GetEntityId(ProviderDto dto)
    {
        return dto.Id;

    }
    [HttpPatch]
    public async Task<IActionResult> UpdatePartial(int id, int providerId, [FromBody] ProvideUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _providerBusiness.UpdatePartialAsync(dto);
            return Ok(new { Success = result });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al actualizar parcialmente proveedor: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar parcialmente proveedor: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpDelete("logic/{id}")]
    public async Task<IActionResult> DeleteLogic(int id)
    {
        try
        {
            var dto = new GenericDto { Id = id, Active = false }; // Se inicializa la propiedad requerida 'Status'
            var result = await _providerBusiness.ActiveAsync(dto);
            if (!result)
                return NotFound($"Proveedor con ID {id} no encontrado");
            return Ok(new { Success = true });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al eliminar lógicamente provider: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar lógicamente provider con ID {id}: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

}