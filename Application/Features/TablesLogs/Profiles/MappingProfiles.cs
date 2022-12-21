using Application.Features.Services.Dtos;
using Application.Features.TablesLogs.Dtos;
using Application.Features.TablesLogs.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.TablesLogs.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<TablesLog, TablesLogListDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(p => p.UserName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
                .ForMember(p => p.ItemId, opt => opt.MapFrom(c => c.ItemId)).ReverseMap();
            CreateMap<IPaginate<TablesLog>, TablesLogListModel>().ReverseMap();
        }
    }
}
