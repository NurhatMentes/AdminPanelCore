using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Category.Constants;

namespace Application.Features.Category.Rules
{
    public class CategoryBusinessRules
    {
        ICategoryRepository _repository;
        private IUserRepository _userRepository;

        public CategoryBusinessRules(ICategoryRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task UserShouldExistWhenRequested(int userId)
        {
            var user = await _userRepository.GetAsync(a => a.Id == userId);
            if (user == null) throw new BusinessException(Messages.ShouldExistWhenRequested);
        }
    }
}
