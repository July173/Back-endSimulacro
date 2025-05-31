using Business.Interfaces;
using Entity.Dtos.Base;
using Entity.Dtos.EmployeeDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements;

[Route("api/[controller]")]

public class EmployeeController : GenericController<EmployeeDto, Employee>, IEmployeeController
{
    private readonly IEmployeeBusiness _employeeBusiness;
    public EmployeeController(IEmployeeBusiness employeeBusiness, ILogger<EmployeeController> logger)
        : base(employeeBusiness, logger)
    {
        _employeeBusiness = employeeBusiness;
    }

    protected override int GetEntityId(EmployeeDto dto)
    {
        return dto.Id;
    }

    [HttpPatch]

    public async Task<IActionResult> UpdatePartial(int id, int employeeId, [FromBody] EmployeeUpdateDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _employeeBusiness.UpdatePartialAsync(dto);
            return Ok(new { Success = result });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al actualizar parcialmente el empleado: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar parcialmente el empleado: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpDelete("logic/{id}")]

    public async Task<IActionResult> DeleteLogic(int id)
    {
        try
        {
            var dto = new GenericDto { Id = id, Active = false }; // Se inicializa la propiedad requerida 'Status'
            var result = await _employeeBusiness.ActiveAsync(dto);
            if (!result)
                return NotFound($"Empleado con ID {id} no encontrado");
            return Ok(new { Success = true });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error de validación al eliminar lógicamente empleado: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar lógicamente el empleado con ID {id}: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
}