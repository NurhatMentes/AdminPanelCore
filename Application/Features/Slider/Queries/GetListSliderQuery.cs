using Application.Features.Slider.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Slider.Queries
{
    public class GetListSliderQuery : IRequest<SliderListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSliderQueryHandler : IRequestHandler<GetListSliderQuery, SliderListModel>
        {
            private readonly ISliderRepository _repository;
            private readonly IMapper _mapper;

            public GetListSliderQueryHandler(ISliderRepository modelRepository, IMapper mapper)
            {
                _repository = modelRepository;
                _mapper = mapper;
            }

            public async Task<SliderListModel> Handle(GetListSliderQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.Slider> sliderAsync = await _repository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                //data model
                SliderListModel mappedListModel = _mapper.Map<SliderListModel>(sliderAsync);

                return mappedListModel;
            }
        }
    }
}
