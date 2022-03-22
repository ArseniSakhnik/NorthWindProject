using FluentValidation;

namespace NorthWindProject.Application.Common.ShareValidators
{
    public class LongStringValidator : AbstractValidator<string>
    {
        public LongStringValidator()
        {
            RuleFor(str => str.Length)
                .LessThanOrEqualTo(250);
        }
    }
}