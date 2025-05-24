using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public class Form : GenericModel
    {
     
        public string Path { get; set; }

        public ICollection<FormModule> FormModule { get; set; }

        public ICollection<RolFormPermission> RolFormPermissions { get; set; }

       
    }
}
