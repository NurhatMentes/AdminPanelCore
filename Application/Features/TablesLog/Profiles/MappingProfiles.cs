using Application.Features.TablesLog.Commands.CreateTablesLog;
using Application.Features.TablesLog.Dtos;
using AutoMapper;

namespace Application.Features.TablesLog.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.TablesLog, CreateTablesLogCommand>().ReverseMap();
            CreateMap<Domain.Entities.TablesLog, CreatedTablesLogDto>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(p => p.User.Id))
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id)).ReverseMap();
        }
    }
}
