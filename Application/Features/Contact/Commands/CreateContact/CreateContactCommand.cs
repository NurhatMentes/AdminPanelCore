using Application.Features.Contact.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Contact.Commands.CreateContact
{
    public class CreateContactCommand:IRequest<CreatedContactDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1" };
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
