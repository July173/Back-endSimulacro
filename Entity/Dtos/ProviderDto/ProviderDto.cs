using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;

namespace Entity.Dtos.ProviderDto
{
    public  class ProviderDto : UpdateDtoBase
    {
        public bool Active { get; set; }
        public int UserId { get; set; }
        public string TaxId { get; set; } // NIT O RUT
        public string BusinessType { get; set; } // Tipo de negocio
        public string ServicesProvided { get; set; } // Servicios que ofrece    
    }
}
