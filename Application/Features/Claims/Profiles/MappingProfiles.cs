using Application.Features.Claims.Commands.CreateOperationClaim;
using Application.Features.Claims.Commands.DeleteOperationClaim;
using Application.Features.Claims.Commands.UptadeOperationClaim;
using Application.Features.Claims.Dtos;
using Application.Features.Claims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Claims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
        }
    }
}
