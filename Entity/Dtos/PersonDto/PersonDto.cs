using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;

namespace Entity.DTOs.Person
{
    public class PersonDto : GenericDto
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string TypeIdentification { get; set; }
        public long NumberIdentification { get; set; }

    }
}
