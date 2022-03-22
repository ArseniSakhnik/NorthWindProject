using FluentValidation;
using NorthWindProject.Application.Common.ShareValidators;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckFizService
{
    public class CreatePurchaseToVacuumTruckIndividualServiceCommandValidator : AbstractValidator<CreatePurchaseToVacuumTruckIndividualServiceCommand>
    {
        public CreatePurchaseToVacuumTruckIndividualServiceCommandValidator(ICurrentUserService currentUserService)
        {
            RuleFor(command => command)
                .Must(_ => currentUserService.UserId != 0)
                .WithMessage("Необходимо аутентифицироваться для отправки заявки");

            RuleFor(command => command.PassportSerialNumber)
                .SetValidator(new ShortStringValidator())
                .WithMessage("Недопустимая длина символов");

            RuleFor(command => command.PassportId)
                .SetValidator(new ShortStringValidator())
                .WithMessage("Недопустимая длина символов");

            RuleFor(command => command.PassportIssued)
                .SetValidator(new ShortStringValidator())
                .WithMessage("Недопустимая длина символов");

            RuleFor(command => command.PassportIssueDate)
                .SetValidator(new ShortStringValidator())
                .WithMessage("Недопустимая длина символов");

            RuleFor(command => command.DivisionCode)
                .SetValidator(new ShortStringValidator())
                .WithMessage("Недопустимая длина символов");

            RuleFor(command => command.RegistrationAddress)
                .SetValidator(new LongStringValidator())
                .WithMessage("Недопустимая длина символов");

            RuleFor(command => command.TerritoryAddress)
                .SetValidator(new LongStringValidator())
                .WithMessage("Недопустимая длина символов");
        }
    }
}