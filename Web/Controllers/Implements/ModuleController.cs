using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.DTOs.Module;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;
namespace Web.Controllers.Implements;

[Route("api/[controller]")]

public class ModuleController : GenericController<ModuleDto, Module>, IModuleController
{
    private readonly IModuleBusiness _moduleBusiness;
    public ModuleController(IModuleBusiness moduleBusiness, ILogger<ModuleController> logger)
        : base(moduleBusiness, logger)
    {
        _moduleBusiness = moduleBusiness;
    }

    protected override int GetEntityId(ModuleDto dto)
    {
        return dto.Id;
    }
    

    [HttpPatch]
    public async Task<IActionResult> UpdatePartial(int id, int moduleId, [FromBody] ModuleUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _moduleBusiness.UpdatePartialAsync(dto);
            return Ok(new { Success = result });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al actualizar parcialmente el módulo: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar parcialmente el módulo: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }


    [HttpDelete("logic/{id}")]

    public async Task<IActionResult> DeleteLogic(int id)
    {
        try
        {
            var dto = new GenericDto { Id = id, Active = false }; // Se inicializa la propiedad requerida 'Status'
            var result = await _moduleBusiness.ActiveAsync(dto);
            if (!result)
                return NotFound($"Módulo con ID {id} no encontrado");
            return Ok(new { Success = true });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al eliminar lógicamente módulo: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar lógicamente el módulo con ID {id}: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
}