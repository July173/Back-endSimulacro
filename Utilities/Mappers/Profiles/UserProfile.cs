using AutoMapper;
using Entity.Dtos.UserDTO;
using Entity.Model;


namespace Utilities.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        { 
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
