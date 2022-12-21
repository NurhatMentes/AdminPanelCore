using Application.Features.TablesLogs.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.TablesLogs.Queries
{
    public class GetListTablesLogQuery:IRequest<TablesLogListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListTablesLogQueryHandler : IRequestHandler<GetListTablesLogQuery, TablesLogListModel>
        {
            private readonly ITablesLogRepository _repository;
            private readonly IMapper _mapper;

            public GetListTablesLogQueryHandler(ITablesLogRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<TablesLogListModel> Handle(GetListTablesLogQuery request, CancellationToken cancellationToken)
            {
                IPaginate<TablesLog> tablesLogAsync = await _repository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                TablesLogListModel mappedListModel = _mapper.Map<TablesLogListModel>(tablesLogAsync);

                return mappedListModel;
            }
        }
    }
}
