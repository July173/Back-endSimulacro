using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.Neighborhood;
using Entity.Dtos.ProviderDto;
using Entity.Model;

namespace Business.Interfaces
{
    public interface INeighborhoodBusiness : IBaseBusiness<Neighborhood, NeighborhoodDto>
    {
        Task<bool> UpdatePartialAsync(NeighborhoodUpdateDto dto);
        Task<bool> ActiveAsync(GenericDto dto);
    }
}
