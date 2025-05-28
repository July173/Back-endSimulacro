using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Model
{
    public class Neighborhood : GenericModel
    {
        public int CityId { get; set; }
        public City City { get; set; }
        public User User { get; set; }
        public string CodePostal { get; set; }
    }
}
