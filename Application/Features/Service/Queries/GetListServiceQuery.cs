using Application.Features.Service.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Service.Queries
{
    public class GetListServiceQuery:IRequest<ServiceListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListServiceQueryHandler : IRequestHandler<GetListServiceQuery, ServiceListModel>
        {
            private readonly IServiceRepository _repository;
            private readonly IMapper _mapper;

            public GetListServiceQueryHandler(IServiceRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ServiceListModel> Handle(GetListServiceQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.Service> sliderAsync = await _repository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ServiceListModel mappedListModel = _mapper.Map<ServiceListModel>(sliderAsync);

                return mappedListModel;
            }
        }
    }
}
