using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Dtos.Neighborhood;
using Entity.Dtos.UserDTO;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class NeighborhoodProfile :Profile
    {
        public NeighborhoodProfile()
        {
            CreateMap<Neighborhood, NeighborhoodDto>().ReverseMap();
        }
    }
}
