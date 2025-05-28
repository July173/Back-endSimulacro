using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.DTOs.FormModule;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class FormModuleProfile :Profile
    {
        public FormModuleProfile()
        {
            CreateMap<FormModule, FormModuleDto>().ReverseMap();
        }
    }
}
