using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public class RolFormPermission : BaseModel
    {
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public int FormId { get; set; }
        public Form Form { get; set; }


    }
}
