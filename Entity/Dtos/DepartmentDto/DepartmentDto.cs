using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Model;

namespace Entity.Dtos.DepartmentDto
{
    public class DepartmentDto : UpdateDtoBase
    {
        public bool Active { get; set; }
        public string DepartmentCode { get; set; }
        public int CountryId { get; set; }
    }
}
