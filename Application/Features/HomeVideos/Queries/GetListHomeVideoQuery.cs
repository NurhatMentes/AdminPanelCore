using Application.Features.HomeVideo.Models;
using Application.Features.SubCategories.Models;
using Application.Features.SubCategories.Queries;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HomeVideos.Queries
{
    public class GetListHomeVideoQuery : IRequest<HomeVideoListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListHomeVideoQueryHandler : IRequestHandler<GetListHomeVideoQuery, HomeVideoListModel>
        {
            private readonly IHomeVideoRepository _repository;
            private readonly IMapper _mapper;

            public GetListHomeVideoQueryHandler(IHomeVideoRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<HomeVideoListModel> Handle(GetListHomeVideoQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.HomeVideo> homeVideoAsync = await _repository.GetListAsync(
                    include: m => m
                        .Include(m => m.User),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                //data model
                HomeVideoListModel mappedListModel = _mapper.Map<HomeVideoListModel>(homeVideoAsync);

                return mappedListModel;
            }
        }
    }
}
