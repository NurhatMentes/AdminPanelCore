using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Application.Features.Service.Constants;

namespace Application.Features.Service.Rules
{
    public class ServiceBusinessRules
    {
        IServiceRepository _repository;
        private IUserRepository _userRepository;

        public ServiceBusinessRules(IServiceRepository repository, IUserRepository userRepository)
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
