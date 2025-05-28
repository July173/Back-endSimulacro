using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Model;

namespace Entity.Dtos.Neighborhood
{
    public  class NeighborhoodDto : UpdateDtoBase
    {
        public bool Active { get; set; }
        public int CityId { get; set; }
        public string CodePostal { get; set; }
    }
}
