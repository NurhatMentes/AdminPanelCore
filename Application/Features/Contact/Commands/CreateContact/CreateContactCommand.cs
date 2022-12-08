using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Contact.Dtos;
using Application.Features.Contact.Rules;
using Application.Features.Slider.Commands.CreateSlider;
using Application.Features.Slider.Dtos;
using Application.Features.Slider.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Contact.Commands.CreateContact
{
    public class CreateContactCommand:IRequest<CreatedContactDto>
    {
        public int? UserId { get; set; }
        public string Adress { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string EmailPassword { get; set; }
        public string Whatsapp { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

        public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CreatedContactDto>
        {
            private readonly IContactRepository _repository;
            private readonly IMapper _mapper;
            

            public CreateContactCommandHandler(IContactRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreatedContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Contact mapped = _mapper.Map<Domain.Entities.Contact>(request);
                Domain.Entities.Contact created = await _repository.AddAsync(mapped);
                CreatedContactDto createdDto = _mapper.Map<CreatedContactDto>(created);

                return createdDto;
            }
        }
    }
}
