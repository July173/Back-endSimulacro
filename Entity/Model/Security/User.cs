using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public class User : BaseModel
    {
        public  string Email { get; set; }
        public  string Password { get; set; }
        public  IEnumerable<RolUser> RolUsers { get; set; }
        public Neighborhood Neighborhood { get; set; }
        public int NeighborhoodId { get; set; }
        public Person Person { get; set; }

        public int PersonId { get; set; }   
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public Provider Provider { get; set; }
    }
}
