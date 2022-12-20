using Application.Features.Contact.Dtos;
using Application.Features.Contact.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Contact.Commands.UpdateContact
{
    public class UpdateContactCommand:IRequest<UpdatedContactDto>, ISecuredRequest
    {
        public string[] Roles => new[] { "0", "1" };
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public string Adress { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string EmailPassword { get; set; }
        public string Whatsapp { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

        public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, UpdatedContactDto>
        {
            private readonly IContactRepository _repository;
            private readonly IMapper _mapper;
            private readonly ContactBusinessRules _businessRules;

            public UpdateContactCommandHandler(IContactRepository repository, IMapper mapper, ContactBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatedContactDto> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.UserShouldExistWhenRequested(request.EmendatorAdminId);
                Domain.Entities.Contact mapped = _mapper.Map<Domain.Entities.Contact>(request);
                Domain.Entities.Contact updated = await _repository.UpdateAsync(mapped);
                UpdatedContactDto uptadedDto = _mapper.Map<UpdatedContactDto>(updated);

                return uptadedDto;
            }
        }
    }
}
