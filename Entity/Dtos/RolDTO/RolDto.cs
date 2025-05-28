using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Entity.Dtos.Base;
using System.ComponentModel.Design;

namespace Entity.Dtos.RolDTO
{
    /// <summary>
    /// DTO para mostrar información básica de un rol (operación GET ALL,CREATE,UPDATE(PATCH-PUT))
    /// </summary>
    public class RolDto : UpdateDtoBase
    {
        public bool Active { get; set; }
    }
}
