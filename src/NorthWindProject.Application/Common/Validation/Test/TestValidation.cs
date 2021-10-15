using FluentValidation;
using NorthWindProject.Application.Features.Test.Commands;

namespace NorthWindProject.Application.Common.Validation.Test
{
    public class TestValidation : AbstractValidator<AddTestCommand>
    {
        public TestValidation()
        {
            RuleFor(test => test.Name)
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым");
        }
    }
}