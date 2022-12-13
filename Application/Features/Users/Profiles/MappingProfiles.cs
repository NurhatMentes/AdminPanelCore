using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;


namespace Application.Features.Users.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UpdatedUserDto>().ReverseMap();
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
