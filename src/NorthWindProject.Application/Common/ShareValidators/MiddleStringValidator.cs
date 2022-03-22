using FluentValidation;

namespace NorthWindProject.Application.Common.ShareValidators
{
    public class MiddleStringValidator : AbstractValidator<string>
    {
        public MiddleStringValidator()
        {
            RuleFor(str => str.Length)
                .LessThanOrEqualTo(50);
        }
    }
}