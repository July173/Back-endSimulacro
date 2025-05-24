using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public  class Employee : GenericModel
    {
     
        public User User { get; set; }
        public int UserId { get; set; }
        public string Position { get; set; } // Cargo del empleado
        public string Department { get; set; } // Departamento del empleado
        public string ContractType { get; set; } // Tipo de contrato (indefinido, temporal, etc.)
        public DateTime HireDate { get; set; } // Fecha de contratación
        public decimal Salary { get; set; } // Salario del empleado


    }
}
