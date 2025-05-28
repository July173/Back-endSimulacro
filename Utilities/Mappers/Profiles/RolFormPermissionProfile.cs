using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.DTOs;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class RolFormPermissionProfile : Profile
    {
        public RolFormPermissionProfile() 
        {
            CreateMap<RolFormPermission, RolFormPermissionDto>().ReverseMap();
        }
    }
}
