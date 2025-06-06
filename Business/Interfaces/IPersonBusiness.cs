﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Base;
using Entity.Dtos.ProviderDto;
using Entity.DTOs.Person;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IPersonBusiness : IBaseBusiness<Person, PersonDto>
    {
        Task<bool> UpdatePartialAsync(PersonUpdateDto dto);
        Task<bool> ActiveAsync(GenericDto dto);
    }
}
