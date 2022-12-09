using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.AboutUs.Commands.CreateAboutUs;
using Application.Features.AboutUs.Dtos;
using Application.Features.AboutUs.Rules;
using Application.Features.Contact.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.AboutUs.Commands.UpdateAboutUs
{
    public class UpdateAboutUsCommand:IRequest<UpdatedAboutUsDto>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int EmendatorAdminId { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public class UpdateAboutUsCommandHandler : IRequestHandler<UpdateAboutUsCommand, UpdatedAboutUsDto>
        {
            private readonly IAboutUsRepository _repository;
            private readonly IMapper _mapper;
            private readonly AboutUsBusinessRules _rules;


            public UpdateAboutUsCommandHandler(IAboutUsRepository repository, IMapper mapper, AboutUsBusinessRules rules)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<UpdatedAboutUsDto> Handle(UpdateAboutUsCommand request, CancellationToken cancellationToken)
            {
                await _rules.UserShouldExistWhenRequested(request.EmendatorAdminId);
                Domain.Entities.AboutUs mapped = _mapper.Map<Domain.Entities.AboutUs>(request);
                Domain.Entities.AboutUs updated = await _repository.UpdateAsync(mapped);
                UpdatedAboutUsDto uptadedDto = _mapper.Map<UpdatedAboutUsDto>(updated);

                return uptadedDto;
            }
        }
    }
}
