using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;

namespace Entity.Dtos.ChangeLogDto
{
    public  class ChangeLogData : GenericDto
    {
        public string UserName { get; set; }
        public int IdTable { get; set; }
        public string TableName { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string Action { get; set; }
    }
}
