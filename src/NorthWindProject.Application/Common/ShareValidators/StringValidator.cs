using FluentValidation;

namespace NorthWindProject.Application.Common.ShareValidators
{
    public class StringValidator : AbstractValidator<string>
    {
        public StringValidator()
        {
            RuleFor(str => str.Length)
                .LessThanOrEqualTo(250)
                .WithMessage("Недопустимая длина символов");
        }
    }
}