using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public class City : GenericModel
    {
        public string CityCode { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Neighborhood> Neighborhoods { get; set; }
        public ICollection<Department> Departments { get; set; }

    }
}
