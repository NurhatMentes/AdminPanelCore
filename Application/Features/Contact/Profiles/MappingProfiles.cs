using Application.Features.Contact.Commands.CreateContact;
using Application.Features.Contact.Dtos;
using Application.Features.Contact.Models;
using Application.Features.Slider.Commands.CreateSlider;
using Application.Features.Slider.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Contact.Commands.UpdateContact;

namespace Application.Features.Contact.Profiles
{
    public class MappingProfiles: Profile
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
