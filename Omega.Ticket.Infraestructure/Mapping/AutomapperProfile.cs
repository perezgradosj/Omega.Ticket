using Omega.Ticket.Core.Domain.DTO.Profile;
using Omega.Ticket.Core.Domain.DTO.User;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Mapping
{
    public class AutomapperProfile : AutoMapper.Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateProfileDTO, Profile>();
            CreateMap<CreateUserDTO, User>();
        }
    }
}
