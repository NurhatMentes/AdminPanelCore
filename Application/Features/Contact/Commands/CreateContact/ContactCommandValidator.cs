using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Contact.Commands.CreateContact
{
    public class ContactCommandValidator:AbstractValidator<CreateContactCommand>
    {
        public ContactCommandValidator()
        {
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.Tel).Length(10, 22);
        }
    }
}
