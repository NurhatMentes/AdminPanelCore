using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserCanNotBeDuplicatedWhenInserted(string email)
        {
            IPaginate<ExtendedUser> result = await _userRepository.GetListAsync(u => u.Email == email);
            if (result.Items.Any()) throw new BusinessException(Messages.MailCanNotBeDuplicatedWhenInserted);
        }

        public void UserShouldExistWhenRequested(ExtendedUser user)
        {
            if (user == null) throw new BusinessException(Messages.ShouldExistWhenRequested);
        }
    }
}