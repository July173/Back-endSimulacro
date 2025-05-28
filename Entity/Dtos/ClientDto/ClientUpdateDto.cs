using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Model;

namespace Entity.Dtos.ClientDto
{
    public class ClientUpdateDto : UpdateDtoBase
    {
        public string PaymentTerms { get; set; }
        public int UserId { get; set; }
    } 
}
