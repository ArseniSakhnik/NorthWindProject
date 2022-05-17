using FluentValidation;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.ShareValidators;

namespace NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckYurContract
{
    public class
        CreateVacuumTruckYurContractCommandValidator : AbstractValidator<CreateVacuumTruckYurContractCommand>
    {
        public CreateVacuumTruckYurContractCommandValidator(ICurrentUserService currentUserService)
        {
            
        }
    }
}