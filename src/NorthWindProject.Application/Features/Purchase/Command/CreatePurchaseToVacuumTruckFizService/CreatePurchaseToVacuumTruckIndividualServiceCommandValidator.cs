using FluentValidation;
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
            
            // RuleFor(command => command.)
        }
    }
}