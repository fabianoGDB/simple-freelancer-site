using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail not valid");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Must be at least 8 characters long, must include at least one uppercase, one lowercase letter, one number, one special character (!#@$%&).");

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required");
        }
    public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }

    }

}
