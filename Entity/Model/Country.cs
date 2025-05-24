using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public class Country : GenericModel
    {
        public string CountryCode { get; set; }

        public ICollection<Department> Departments { get; set; }

    }
}
