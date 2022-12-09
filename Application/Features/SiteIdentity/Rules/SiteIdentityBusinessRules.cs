using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SiteIdentity.Constants;

namespace Application.Features.SiteIdentity.Rules
{
    public class SiteIdentityBusinessRules
    {
        ISiteIdentityRepository _repository;
        private IUserRepository _userRepository;

        public SiteIdentityBusinessRules(ISiteIdentityRepository sliderRepository, IUserRepository userRepository)
        {
            _repository = sliderRepository;
            _userRepository = userRepository;
        }

        public async Task UserShouldExistWhenRequested(int userId)
        {
            var user = await _userRepository.GetAsync(a => a.Id == userId);
            if (user == null) throw new BusinessException(Messages.ShouldExistWhenRequested);
        }
    }
}
