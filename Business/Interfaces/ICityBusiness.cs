using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.CityDto;
using Entity.Dtos.DepartmentDto;
using Entity.Model;

namespace Business.Interfaces
{
    public interface ICityBusiness : IBaseBusiness<City, CityDto>
    {
        Task<bool> UpdatePartialAsync(CityUpdateDto dto);
        Task<bool> ActiveAsync(GenericDto dto);
    }
}
