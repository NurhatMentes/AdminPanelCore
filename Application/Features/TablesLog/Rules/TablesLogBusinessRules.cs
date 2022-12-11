using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Application.Features.TablesLog.Constants;

namespace Application.Features.TablesLog.Rules
{
    public class TablesLogBusinessRules
    {
        private ITablesLogRepository _repository;
        private IUserRepository _userRepository;

        public TablesLogBusinessRules(ITablesLogRepository repository, IUserRepository userRepository)
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
