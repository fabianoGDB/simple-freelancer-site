using DevFreela.Application.Commands.CreateProject;
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
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Tile must have at most 30 chars");

            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Tile is required");

            RuleFor(p => p.Description)
               .MaximumLength(255)
               .WithMessage("Tile must have at most 255 chars");

            RuleFor(p => p.Description)
               .NotEmpty()
               .NotNull()
               .WithMessage("Tile is required");
        }
    }

}
