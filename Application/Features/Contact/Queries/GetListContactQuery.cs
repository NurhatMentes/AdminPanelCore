using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Contact.Models;
using Application.Features.Slider.Models;
using Application.Features.Slider.Queries;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Contact.Queries
{
    public class GetListContactQuery:IRequest<ContactListModel>
    {
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
