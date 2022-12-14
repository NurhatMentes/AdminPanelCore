using Application.Auth.Dtos;
using Application.Auth.Rules;
using Application.Services.Repositories;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Domain.Entities;
using Core.CrossCuttingConcerns.Exceptions;
using Application.Features.Auth.Constants;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginQuery : IRequest<RefreshedTokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginQuery, RefreshedTokenDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IUserRepository userRepository, IOperationClaimRepository operationClaimRepository, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _operationClaimRepository = operationClaimRepository;
                _tokenHelper = tokenHelper;
                _authBusinessRules = authBusinessRules;
            }
            public async Task<RefreshedTokenDto> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                ExtendedUser? user = await _userRepository.GetAsync(u => u.Email == request.Email);

                _authBusinessRules.UserShouldExistWhenRequested(user!);

                if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                    throw new BusinessException(Messages.WrongInformation);

                var roles = await _operationClaimRepository.GetListAsync(o => o.Id==user.Id);

                AccessToken accessToken = _tokenHelper.CreateToken(user, roles.Items);

                return new RefreshedTokenDto { AccessToken = accessToken };
            }
        }
    }
}