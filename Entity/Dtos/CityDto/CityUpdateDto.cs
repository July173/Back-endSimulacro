using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Model;

namespace Entity.Dtos.CityDto
{
    public class CityUpdateDto : UpdateDtoBase
    {
        public string CityCode { get; set; }
        public int DepartmentId { get; set; }
    }
}
