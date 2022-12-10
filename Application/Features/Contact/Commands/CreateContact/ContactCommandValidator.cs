using FluentValidation;

namespace Application.Features.Contact.Commands.CreateContact
{
    public class ContactCommandValidator:AbstractValidator<CreateContactCommand>
    {
        public ContactCommandValidator()
        {
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.Adress).NotEmpty();
            RuleFor(c => c.Tel).Length(10, 22);
        }
    }
}
