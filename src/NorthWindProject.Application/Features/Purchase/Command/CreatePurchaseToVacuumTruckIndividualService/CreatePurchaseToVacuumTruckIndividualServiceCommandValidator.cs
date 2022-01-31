using FluentValidation;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckIndividualService
{
    public class CreatePurchaseToVacuumTruckIndividualServiceCommandValidator : AbstractValidator<CreatePurchaseToVacuumTruckIndividualServiceCommand>
    {
        public CreatePurchaseToVacuumTruckIndividualServiceCommandValidator()
        {
            RuleFor(command => command.Email)
                .NotEmpty()
                .WithMessage("Необходимо указать ваш email")
                .EmailAddress()
                .WithMessage("Укажите валидный адрес");
            
        }
    }
}