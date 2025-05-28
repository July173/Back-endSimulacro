using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Enums;
using Entity.Model;

namespace Entity.Dtos.EmployeeDto
{
    public class EmployeeDto : UpdateDtoBase
    { 
        public bool Active { get; set; }
        public int UserId { get; set; }
        public string Position { get; set; } // Cargo del empleado
        public string Department { get; set; } // Departamento del empleado
        public ContractType ContractType { get; set; } // Tipo de contrato (indefinido, temporal, etc.)
        public DateTime HireDate { get; set; } // Fecha de contratación
        public decimal Salary { get; set; } // Salario del empleado
    }
}
