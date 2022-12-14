using Application.Features.Blogs.Commands.CreateBlog;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Commands.UpdateBlog
{
    internal class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator()
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

            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
