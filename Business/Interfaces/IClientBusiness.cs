using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.ClientDto;
using Entity.Dtos.DepartmentDto;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IClientBusiness: IBaseBusiness<Client, ClientDto>
    {
        Task<bool> UpdatePartialAsync(ClientUpdateDto dto);
        Task<bool> ActiveAsync(GenericDto dto);
    }
}
