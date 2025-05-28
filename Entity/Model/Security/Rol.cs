using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public class Rol : GenericModel
    {
     
        public  IEnumerable<RolUser> RolUsers { get; set; } 
    }
}
