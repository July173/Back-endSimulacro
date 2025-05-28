using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;

namespace Entity.DTOs.FormModule
{
    public class FormModuleDto : BaseDto
    {
        public int FormId { get; set; }

        public int ModuleId { get; set; }
    }
}
