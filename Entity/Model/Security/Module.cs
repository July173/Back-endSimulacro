using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public class Module : GenericModel
    {
        public ICollection<FormModule> FormModule { get; set; }
      
    }
}
