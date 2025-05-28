using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.DTOs.Module;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class ModuleProfile :Profile
    {
        public ModuleProfile()
        {
            CreateMap<Module, ModuleDto>().ReverseMap();
        }
    }
}
