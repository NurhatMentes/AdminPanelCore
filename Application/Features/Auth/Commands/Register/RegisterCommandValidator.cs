using Application.Features.Auth.Commands.Login;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(u => u.UserForRegisterDto.Password).MinimumLength(7);
            RuleFor(u => u.UserForRegisterDto.Email).EmailAddress<RegisterCommand>();
            RuleFor(u => u.UserForRegisterDto.FirstName).NotNull();
        }
    }
}
