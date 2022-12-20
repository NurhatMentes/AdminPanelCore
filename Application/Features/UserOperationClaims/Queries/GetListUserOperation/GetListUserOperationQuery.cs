using Application.Features.UserOperationClaims.Model;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperationClaims.Commands.Queries.GetListUserOperation
{
    public class GetListUserOperationQuery:IRequest<UserOperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserOperationQueryHandler:IRequestHandler<GetListUserOperationQuery,UserOperationClaimListModel>
        {
            private readonly IMapper _mapper;
            private readonly IUserOperationClaimRepository _repository;

            public GetListUserOperationQueryHandler(IMapper mapper, IUserOperationClaimRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<UserOperationClaimListModel> Handle(GetListUserOperationQuery request, CancellationToken cancellationToken)
            {

                IPaginate<UserOperationClaim> UserOperationClaim = await _repository.GetListAsync(
                   include: m => m.Include(m => m.OperationClaim).Include(m => m.User),
                   index: request.PageRequest.Page, size: request.PageRequest.PageSize); 
                UserOperationClaimListModel mappedUserOperationClaimListModel = _mapper.Map<UserOperationClaimListModel>(UserOperationClaim);
                return mappedUserOperationClaimListModel;
            }
        }
    }
}
