using FluentValidation;

namespace NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckFizContract
{
    public class CreateVacuumTruckFizContractCommandValidator
        : AbstractValidator<CreateVacuumTruckFizContractCommand>
    {
        // public CreatePurchaseToVacuumTruckYurPurchaseCommandValidator(ICurrentUserService currentUserService)
        // {
        //     RuleFor(command => command)
        //         .Must(_ => currentUserService.UserId != 0)
        //         .WithMessage("Необходимо аутентифицироваться для отправки заявки");
        //
        //     RuleFor(command => command.IndividualEntrepreneurShortName)
        //         .SetValidator(new StringValidator());
        //
        //     RuleFor(command => command.TerritoryAddress)
        //         .SetValidator(new StringValidator());
        //
        //     RuleFor(command => command.OGRN)
        //         .SetValidator(new StringValidator());
        //
        //     RuleFor(command => command.INN)
        //         .SetValidator(new StringValidator());
        //
        //     RuleFor(command => command.KPP)
        //         .SetValidator(new StringValidator());
        //
        //     RuleFor(command => command.LegalAddress)
        //         .SetValidator(new StringValidator());
        // }
    }
}