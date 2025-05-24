using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public  class Provider : GenericModel

    {
    
        public User User { get; set; }
        public int UserId { get; set; }
        public string TaxId { get; set; } // NIT O RUT
        public string BusinessType { get; set; } // Tipo de negocio
        public string ServicesProvided { get; set; } // Servicios que ofrece    
    }
}
