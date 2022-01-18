using System.Diagnostics;
using FluentValidation;

namespace NorthWindProject.Application.Features.Test.Commands
{
    public class AddTestCommandValidator : AbstractValidator<AddTestCommand>
    {
        public AddTestCommandValidator()
        {
            Debug.WriteLine(1);
            RuleFor(command => command.Name)
                .Must(Test)
                .WithMessage("Ошибка валидации");
            RuleFor(command => command.Name)
                .Must(Test)
                .WithMessage("Ошибка валидации 2");
        }

        private bool Test(string name)
        {
            return false;
        }
    }
}