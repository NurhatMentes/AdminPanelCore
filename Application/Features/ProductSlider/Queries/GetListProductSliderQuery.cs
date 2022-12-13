using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProductSlider.Models;
using Application.Features.Slider.Models;
using Application.Features.Slider.Queries;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProductSlider.Queries
{
    public class GetListProductSliderQuery:IRequest<ProductSliderListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProductSliderQueryHandler : IRequestHandler<GetListProductSliderQuery, ProductSliderListModel>
        {
            private readonly IProductSliderRepository _repository;
            private readonly IMapper _mapper;

            public GetListProductSliderQueryHandler(IProductSliderRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ProductSliderListModel> Handle(GetListProductSliderQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.ProductSlider> sliderAsync = await _repository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ProductSliderListModel mappedListModel = _mapper.Map<ProductSliderListModel>(sliderAsync);

                return mappedListModel;
            }
        }
    }
}
