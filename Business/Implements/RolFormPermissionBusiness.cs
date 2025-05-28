using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Data.Implements.RolUserData;
using Data.Interfaces;
using Entity.Dtos.RolUserDTO;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Interfaces;

namespace Business.Implements
{
    public class RolFormPermissionBusiness :BaseBusiness<RolFormPermission, RolFormPermissionDto>, IRolFormPermissionBusiness
    {
        private readonly IRolFormPermissionData _rolFormPermissionData;

        public RolFormPermissionBusiness(IRolFormPermissionData rolFormPermissionData, IMapper mapper, ILogger<RolFormPermissionBusiness> logger, IGenericIHelpers helpers)
            : base(rolFormPermissionData, mapper, logger, helpers)
        {
            _rolFormPermissionData = rolFormPermissionData;
        }
        public async Task<bool> UpdatePartialAsync(RolFormPermissionDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");


            var rolFormPermission = _mapper.Map<RolFormPermission>(dto);
            var result = await _rolFormPermissionData.UpdatePartial(rolFormPermission);
            return result;
        }
    }
}
