using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Slider.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Slider.Rules
{
    public class SliderBusinessRules
    {
        ISliderRepository _sliderRepository;
        private IUserRepository _userRepository;

        public SliderBusinessRules(ISliderRepository sliderRepository, IUserRepository userRepository)
        {
            _sliderRepository = sliderRepository;
            _userRepository = userRepository;
        }

        public async Task UserShouldExistWhenRequested(int userId)
        {
            var user = await _userRepository.GetAsync(a => a.Id == userId);
            if (user == null) throw new BusinessException(Messages.ShouldExistWhenRequested);
        }
    }
}
