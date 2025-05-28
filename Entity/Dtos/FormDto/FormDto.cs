using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;

namespace Entity.DTOs.Form
{
    public class FormDto : UpdateDtoBase
    {

        public string Path { get; set; }
     
        public bool Active { get; set; }
      
    }
}
