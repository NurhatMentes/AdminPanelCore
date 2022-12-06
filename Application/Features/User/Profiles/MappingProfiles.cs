
using Application.Features.User.Commands.CreateUser;
using Application.Features.User.Dtos;
using Application.Features.User.Models;
using AutoMapper;
using Core.Persistence.Paging;


namespace Application.Features.User.Profiles
{
    internal class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Core.Security.Entities.User, UpdateUserCommand>().ReverseMap();
            CreateMap<Core.Security.Entities.User, UpdatedUserDto>().ReverseMap();
            CreateMap<Core.Security.Entities.User, UserListDto>()
                .ForMember(c=>c.Id,opt=>opt.MapFrom(c=>c.Id)).ReverseMap();
            CreateMap<IPaginate<Core.Security.Entities.User>, UserListModel>().ReverseMap();
        }
    }
}
