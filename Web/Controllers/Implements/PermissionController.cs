using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Dtos.PermissionDto;
using Entity.DTOs;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements;

[Route("api/[controller]")]
public class PermissionController : GenericController<PermissionDto, Permission>, IPermissionController
{
    private readonly IPermissionBusiness _permissionBusiness;

    public PermissionController(IPermissionBusiness permissionBusiness, ILogger<PermissionController> logger)
        : base(permissionBusiness, logger)
    {
        _permissionBusiness = permissionBusiness;
    }

    protected override int GetEntityId(PermissionDto dto)
    {
        return dto.Id;
    }

    [HttpPatch]
    public async Task<IActionResult> UpdatePartial(int id, int permissionId, [FromBody] PermissionUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _permissionBusiness.UpdatePartialAsync(dto);
            return Ok(new { Success = result });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al actualizar parcialmente el permiso: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar parcialmente el permiso: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpDelete("logic/{id}")]
    public async Task<IActionResult> DeleteLogic(int id)
    {
        try
        {
            var dto = new GenericDto { Id = id, Active = false }; // Se inicializa la propiedad requerida 'Status'
            var result = await _permissionBusiness.ActiveAsync(dto);
            if (!result)
                return NotFound($"Permiso con ID {id} no encontrado");
            return Ok(new { Success = true });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al eliminar lógicamente permuiso: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar lógicamente el permiso con ID {id}: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
}
