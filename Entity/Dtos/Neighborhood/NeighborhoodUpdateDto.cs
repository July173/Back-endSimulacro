using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;

namespace Entity.Dtos.Neighborhood
{
    public class NeighborhoodUpdateDto : UpdateDtoBase
    {
        public int CityId { get; set; }
        public string CodePostal { get; set; }
    }
}
