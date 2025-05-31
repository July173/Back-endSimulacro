using Microsoft.AspNetCore.Mvc;
using Entity.Model;
using Business.Interfaces;
using Web.Controllers.Interface;
using Entity.DTOs.FormModule;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]

    public class FormModuleController : GenericController<FormModuleDto, FormModule>, IFormModuleController
    {
        private readonly IFormModuleBusiness _formModuleBusiness;
        public FormModuleController(IFormModuleBusiness formModuleBusiness, ILogger<FormModuleController> logger)
            : base(formModuleBusiness, logger)
        {
            _formModuleBusiness = formModuleBusiness;
        }

        protected override int GetEntityId(FormModuleDto dto)
        {
            return dto.Id;
        }


        [HttpPatch("{id}/form/{formId}")]

        public async Task<IActionResult> UpdatePartial(int id, int formId, FormModuleDto dto)
        {
            try
            {
                var result = await _formModuleBusiness.UpdatePartialAsync(dto);
                if (!result)
                    return NotFound($"Asignación de formulario con ID {id} no encontrada");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente asignación de formulario: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente asignación de formulario: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}