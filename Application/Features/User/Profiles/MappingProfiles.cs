using Application.Features.User.Commands.UpdateUser;
using Application.Features.User.Dtos;
using Application.Features.User.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;


namespace Application.Features.User.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Core.Security.Entities.User, UpdateUserCommand>().ReverseMap();
            CreateMap<Core.Security.Entities.User, UpdatedUserDto>().ReverseMap();
            CreateMap<ExtendedUser, UserListDto>()
                .ForMember(c=>c.Id,opt=>opt.MapFrom(c=>c.Id))
                .ForMember(c => c.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(c => c.FirstName, opt => opt.MapFrom(c => c.FirstName))
                .ForMember(c => c.LastName, opt => opt.MapFrom(c => c.LastName))
                .ForMember(c => c.Job, opt => opt.MapFrom(c => c.Job))
                .ForMember(c => c.Phone, opt => opt.MapFrom(c => c.Phone))
                .ForMember(c => c.Status, opt => opt.MapFrom(c => c.Status))
                .ForMember(c => c.PasswordHash, opt => opt.MapFrom(c => c.PasswordHash))
                .ForMember(c => c.PasswordSalt, opt => opt.MapFrom(c => c.PasswordSalt)).ReverseMap();
            CreateMap<IPaginate<ExtendedUser>, UserListModel>().ReverseMap();
        }
    }
}
