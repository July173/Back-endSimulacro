
using AutoMapper;
using Entity.DTOs.Form;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class FormProfile :Profile
    {
        public FormProfile()
        {
            CreateMap<Form, FormDto>().ReverseMap();
        }
    }
}
