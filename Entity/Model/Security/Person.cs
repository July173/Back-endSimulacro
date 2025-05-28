using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Enums;
using Entity.Model.Base;

namespace Entity.Model
{
    public class Person : BaseModel
    {
        public string FirstName { get; set; }
        public string FirstLastName { get; set; }
        public long PhoneNumber { get; set; }
        public string TypeIdentification { get; set; }
        public long NumberIdentification { get; set; }
        public StreetLetter streetLetter { get; set; }
        public StreetType streetType    { get; set; }
        public bool Active { get; set; }
        public User User { get; set; }
        public string Address { get; set; }

    }
}
