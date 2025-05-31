using Business.Interfaces;
using Entity.DTOs;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;
using Web.Controllers.Interface;

namespace Web.Controller.Implements
{
    [Route("api/[controller]")]

    public class RolFormPermissionController : GenericController<RolFormPermissionDto, RolFormPermission>, IRolFormPermissionController
    { 
    
        private readonly IRolFormPermissionBusiness _rolFormPermissionBusiness;

        public RolFormPermissionController(IRolFormPermissionBusiness rolFormPermissionBusiness, ILogger<RolFormPermissionController> logger)
            : base(rolFormPermissionBusiness, logger)
        {
            _rolFormPermissionBusiness = rolFormPermissionBusiness;
        }

        protected override int GetEntityId(RolFormPermissionDto dto)
        {
            return dto.Id;
        }
        [HttpPatch("{id}/rolFormPermission/{rolFormPermission}")]

        public async Task<IActionResult> UpdatePartial(int id, int rolFormPermission, RolFormPermissionDto dto)
        {
            try
            {

                var result = await _rolFormPermissionBusiness.UpdatePartialAsync(dto);
                if (!result)
                    return NotFound($"Asignación de rol con ID {id} no encontrada");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente asignación de rol: {ex.Message}");
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente asignación de rol: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }


     }
}