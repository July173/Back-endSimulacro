using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;

namespace Entity.DTOs.Module
{
    public class ModuleDto : UpdateDtoBase
    {
        public bool Active { get; set; }
        

    }
}
