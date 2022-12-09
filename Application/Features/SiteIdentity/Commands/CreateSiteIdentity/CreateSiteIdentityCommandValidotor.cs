using FluentValidation;


namespace Application.Features.SiteIdentity.Commands.CreateSiteIdentity
{
    public class CreateSiteIdentityCommandValidotor : AbstractValidator<CreateSiteIdentityCommand>
    {
        public CreateSiteIdentityCommandValidotor()
        {
            RuleFor(x => x.Keywords)
                .Must(keywords => keywords.Split(' ').Length > 1)
                .WithMessage("Keywords alanı en az iki kelimeden oluşmalıdır.")
                .Must(keywords => keywords.Split(' ').All(word => word.Trim().Length > 0))
                .WithMessage("Keywords alanı boş kelimeler içeremez.")
                .Must(keywords => keywords.Split(' ').All(word => !string.IsNullOrWhiteSpace(word)))
                .WithMessage("Keywords alanı boşluklar içeremez.")
                .Must(keywords => keywords.Split(' ').All(word => !word.Contains(',')))
                .WithMessage("Keywords alanı virgüller içeremez.")
                .Matches(@"^[^\s,]+([\s]?[^\s,]+)+$")
                .WithMessage("Keywords alanında boşluk ayrılmış kelimeler olmalıdır.");
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
