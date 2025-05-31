using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Dtos.DepartmentDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;
namespace Web.Controllers.Implements;

[Route("api/[controller]")]

public class DepartmentController : GenericController<DepartmentDto, Department>, IDepartmentController
{
    private readonly IDepartmentBusiness _departmentBusiness;
    public DepartmentController(IDepartmentBusiness departmentBusiness, ILogger<DepartmentController> logger)
        : base(departmentBusiness, logger)
    {
        _departmentBusiness = departmentBusiness;
    }

    protected override int GetEntityId(DepartmentDto dto)
    {
        return dto.Id;
    }

    [HttpPatch]

    public async Task<IActionResult> UpdatePartial(int id, int departmentId, [FromBody] DepartmentUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _departmentBusiness.UpdatePartialAsync(dto);
            return Ok(new { Success = result });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al actualizar parcialmente el departamento: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar parcialmente el departamento: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpDelete("logic/{id}")]

    public async Task<IActionResult> DeleteLogic(int id)
    {
        try
        {
            var dto = new GenericDto { Id = id, Active = false }; // Se inicializa la propiedad requerida 'Status'
            var result = await _departmentBusiness.ActiveAsync(dto);
            if (!result)
                return NotFound($"Departamento con ID {id} no encontrado");
            return Ok(new { Success = true });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al eliminar lógicamente departamento: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar lógicamente el departamento con ID {id}: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
}