using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;

namespace Entity.DTOs
{
    public class PermissionDto :UpdateDtoBase
    {
        public bool Active { get; set; }
    }
}
