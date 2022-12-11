using Application.Features.Slider.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Slider.Rules
{
    public class SliderBusinessRules
    {
        ISliderRepository _repository;
        private IUserRepository _userRepository;

        public SliderBusinessRules(ISliderRepository sliderRepository, IUserRepository userRepository)
        {
            _repository = sliderRepository;
            _userRepository = userRepository;
        }

        public async Task UserShouldExistWhenRequested(int userId)
        {
            var user = await _userRepository.GetAsync(a => a.Id == userId);
            if (user == null) throw new BusinessException(Messages.UserShouldExistWhenRequested);
        }
    }
}
