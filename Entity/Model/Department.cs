using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public  class Department : GenericModel
    {
        public string DepartmentCode { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
