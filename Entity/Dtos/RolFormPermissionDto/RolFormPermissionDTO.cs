using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;

namespace Entity.DTOs
{
    public class RolFormPermissionDto : BaseDto
    {
        public int PermissionId { get; set; }
        public int RolId { get; set; }
        public int FormId { get; set; }
    }
}
