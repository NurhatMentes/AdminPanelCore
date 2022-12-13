using Application.Features.TablesLogs.Commands.CreateTablesLog;
using Application.Features.TablesLogs.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.TablesLogs.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<TablesLog, CreateTablesLogCommand>().ReverseMap();
            CreateMap<TablesLog, CreatedTablesLogDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(p => p.User.Id))
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id)).ReverseMap();
        }
    }
}
