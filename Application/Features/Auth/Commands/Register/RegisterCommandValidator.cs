using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(u => u.UserForRegisterDto.Password).MinimumLength(7).NotEmpty().WithMessage("Parola alanı boş geçilemez!")
                .Must(IsPasswordValid).WithMessage("Parolanız en az yedi karakter, en az bir harf ve bir sayı içermelidir!"); ;
            RuleFor(u => u.UserForRegisterDto.Email).EmailAddress<RegisterCommand>();
            RuleFor(u => u.UserForRegisterDto.FirstName).NotNull().MaximumLength(50).WithMessage("Ad alanı 50 karakteri geçemez!"); ;
            RuleFor(u => u.UserForRegisterDto.LastName).NotNull().MaximumLength(50).WithMessage("Soyad alanı 50 karakteri geçemez!"); ;
            RuleFor(u => u.UserForRegisterDto.Phone).Length(10,22);
        }

        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
