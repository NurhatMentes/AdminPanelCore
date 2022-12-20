using Application.Features.Contact.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Contact.Queries
{
    public class GetListContactQuery:IRequest<ContactListModel>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1", "2" };
        public PageRequest PageRequest { get; set; }

        public class GetListContactQueryHandler : IRequestHandler<GetListContactQuery, ContactListModel>
        {
            private readonly IContactRepository _repository;
            private readonly IMapper _mapper;

            public GetListContactQueryHandler(IContactRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ContactListModel> Handle(GetListContactQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.Contact> sliderAsync = await _repository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                //data model
                ContactListModel mappedListModel = _mapper.Map<ContactListModel>(sliderAsync);

                return mappedListModel;
            }
        }
    }
}
