using FluentValidation;
using NorthWindProject.Application.Common.ShareValidators;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckYurPurchase
{
    public class CreatePurchaseToVacuumTruckYurPurchaseCommandValidator 
        : AbstractValidator<CreatePurchaseToVacuumTruckYurPurchaseCommand>
    {
        public CreatePurchaseToVacuumTruckYurPurchaseCommandValidator(ICurrentUserService currentUserService)
        {
            RuleFor(command => command)
                .Must(_ => currentUserService.UserId != 0)
                .WithMessage("Необходимо аутентифицироваться для отправки заявки");
            
            RuleFor(command => command.IndividualEntrepreneurShortName)
                .SetValidator(new StringValidator());

            RuleFor(command => command.TerritoryAddress)
                .SetValidator(new StringValidator());

            RuleFor(command => command.OGRN)
                .SetValidator(new StringValidator());
            
            RuleFor(command => command.INN)
                .SetValidator(new StringValidator());
            
            RuleFor(command => command.KPP)
                .SetValidator(new StringValidator());
            
            RuleFor(command => command.LegalAddress)
                .SetValidator(new StringValidator());
        }
    }
}