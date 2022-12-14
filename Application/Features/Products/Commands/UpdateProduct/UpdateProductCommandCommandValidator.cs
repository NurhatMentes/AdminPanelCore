using FluentValidation;

namespace Application.Features.Products.Commands.UpdateProduct
;

public class UpdateProductCommandCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandCommandValidator()
    {
        RuleFor(x => x.Keywords)
            .Must(keywords => keywords.Split(' ').Length >= 1)
            .WithMessage("Keywords alanı en az bir kelimeden oluşmalıdır.")
            .Must(keywords => keywords.Split(' ').All(word => word.Trim().Length > 0))
            .WithMessage("Keywords alanı boş kelimeler içeremez.")
            .Must(keywords => keywords.Split(' ').All(word => !string.IsNullOrWhiteSpace(word)))
            .WithMessage("Keywords alanı boşluklar içeremez.")
            .Must(keywords => keywords.Split(' ').All(word => !word.Contains(',')))
            .WithMessage("Keywords alanı virgüller içeremez.")
            .Matches(@"^[^\s,]+([\s]?[^\s,]+)+$")
            .WithMessage("Keywords alanında boşluk ayrılmış kelimeler olmalıdır.");

        RuleFor(x => x.Color)
            .Must(keywords => keywords.Split(' ').Length > 1)
            .WithMessage("Renk alanı en az iki kelimeden oluşmalıdır.")
            .Must(keywords => keywords.Split(' ').All(word => word.Trim().Length > 0))
            .WithMessage("Renk alanı boş kelimeler içeremez.")
            .Must(keywords => keywords.Split(' ').All(word => !string.IsNullOrWhiteSpace(word)))
            .WithMessage("Renk alanı boşluklar içeremez.")
            .Must(keywords => keywords.Split(' ').All(word => !word.Contains(',')))
            .WithMessage("Renk alanı virgüller içeremez.")
            .Matches(@"^[^\s,]+([\s]?[^\s,]+)+$")
            .WithMessage("Renk alanında boşluk ayrılmış kelimeler olmalıdır.");

        RuleFor(x => x.Title).NotEmpty();
    }
}