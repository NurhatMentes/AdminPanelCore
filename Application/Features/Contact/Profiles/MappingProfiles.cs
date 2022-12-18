using Application.Features.Contact.Commands.CreateContact;
using Application.Features.Contact.Dtos;
using Application.Features.Contact.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Application.Features.Contact.Commands.UpdateContact;

namespace Application.Features.Contact.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Contact, CreateContactCommand>().ReverseMap();
            CreateMap<Domain.Entities.Contact, CreatedContactDto>()
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(p => p.User.Id))
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id)).ReverseMap();

            CreateMap<Domain.Entities.Contact, UpdateContactCommand>().ReverseMap();
            CreateMap<Domain.Entities.Contact, UpdatedContactDto>()
                .ForMember(p => p.EmendatorAdminId, opt => opt.MapFrom(p => p.User.Id))
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id)).ReverseMap();

            CreateMap<Domain.Entities.Contact, ContactListDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Id)).ReverseMap();
            CreateMap<IPaginate<Domain.Entities.Contact>, ContactListModel>().ReverseMap();
        }
    }
}
