using Application.Auth.Dtos;
using Application.Features.Auth.Commands.Register;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Core.Security.Entities.User, RegisterCommand>().ReverseMap();
            CreateMap<AccessToken, RefreshedTokenDto>().ReverseMap();
        }
    }
}