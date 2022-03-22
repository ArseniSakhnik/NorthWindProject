using FluentValidation;

namespace NorthWindProject.Application.Common.ShareValidators
{
    public class ShortStringValidator : AbstractValidator<string>
    {
        public ShortStringValidator()
        {
            RuleFor(str => str.Length)
                .LessThanOrEqualTo(15);
        }
    }
}