using aspnetcore_api_sample.Models;
using aspnetcore_api_sample.Models.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_api_sample.ModelMapper
{
    public class AoutoMapper:Profile
    {
        public AoutoMapper()
        {
            CreateMap<ViewUsers, User>().ReverseMap();
            CreateMap<View_users_has_roles, users_has_roles>().ReverseMap();
            CreateMap<ValidatedUser, User>().ReverseMap();

        }
    }
}
