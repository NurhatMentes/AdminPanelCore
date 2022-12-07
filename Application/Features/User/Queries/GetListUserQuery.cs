using Application.Features.User.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.User.Queries
{
    public class GetListUserQuery : IRequest<UserListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, UserListModel>
        {
            private readonly IUserRepository _repository;
            private readonly IMapper _mapper;

            public GetListUserQueryHandler(IUserRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {

                IPaginate<ExtendedUser> usersAsync = await _repository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);


                UserListModel mappedListModel = _mapper.Map<UserListModel>(usersAsync);

                return mappedListModel;
            }
        }
    }
}
