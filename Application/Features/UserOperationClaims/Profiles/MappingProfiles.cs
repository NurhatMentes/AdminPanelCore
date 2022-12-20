using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Model;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>()
                .ForMember(c => c.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ForMember(c => c.OperationClaimId, opt => opt.MapFrom(c => c.OperationClaim.Id)).ReverseMap();

            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();

            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>()
                 .ForMember(c => c.UserId, opt => opt.MapFrom(c => c.User.Id))
                  .ForMember(c => c.OperationClaimId, opt => opt.MapFrom(c => c.OperationClaim.Id)).ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
            CreateMap<UserOperationClaim, UserOperationClaimListDto>()
                .ForMember(c => c.OperationClaimName, opt => opt.MapFrom(c => c.OperationClaim.Name))
                .ForMember(c => c.Email, opt => opt.MapFrom(c => c.User.Email))
                .ReverseMap();
        }
    }
}
