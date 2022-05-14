﻿using FluentValidation;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.ShareValidators;

namespace NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckYurContract
{
    public class
        CreateVacuumTruckYurContractCommandValidator : AbstractValidator<
            CreateVacuumTruckYurContractCommand>
    {
        public CreateVacuumTruckYurContractCommandValidator(ICurrentUserService currentUserService)
        {
            RuleFor(command => command)
                .Must(_ => currentUserService.UserId != 0)
                .WithMessage("Необходимо аутентифицироваться для отправки заявки");

            RuleFor(command => command.PassportSerialNumber)
                .SetValidator(new StringValidator());

            RuleFor(command => command.PassportId)
                .SetValidator(new StringValidator());

            RuleFor(command => command.PassportIssued)
                .SetValidator(new StringValidator());

            RuleFor(command => command.PassportIssueDate)
                .SetValidator(new StringValidator());

            RuleFor(command => command.DivisionCode)
                .SetValidator(new StringValidator());

            RuleFor(command => command.RegistrationAddress)
                .SetValidator(new StringValidator());

            RuleFor(command => command.TerritoryAddress)
                .SetValidator(new StringValidator());
        }
    }
}