using FluentValidation;

namespace NorthWindProject.Application.Common.ShareValidators
{
    public class StringValidator : AbstractValidator<string>
    {
        public StringValidator()
        {
            RuleFor(str => str.Trim().Length)
                .LessThanOrEqualTo(500)
                .WithMessage("Недопустимая длина символов");
        }
    }
}