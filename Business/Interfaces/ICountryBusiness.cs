using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.CountryDto;
using Entity.Dtos.DepartmentDto;
using Entity.Model;

namespace Business.Interfaces
{
    public interface ICountryBusiness:  IBaseBusiness<Country, CountryDto>
    {
        Task<bool> UpdatePartialAsync(CountryUpdateDto dto);
        Task<bool> ActiveAsync(GenericDto dto);
    }
}
