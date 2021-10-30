using System;
using System.Collections.Generic;
using System.ComponentModel;
using FluentValidation;
using NorthWindProject.Application.Entities.Service;

namespace NorthWindProject.Application.Features.Services.Commands
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(command => command.ServiceProps)
                .Must(ServicePropsValidation)
                .WithMessage("Проверьте правильность заполненных полей");

            RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Необходимо ввести имя сервиса");
        }

        private bool ServicePropsValidation(IList<ServiceProp> serviceProps)
        {
            foreach (var serviceProp in serviceProps)
            {
                var isValid = true;
                switch (serviceProp.ServicePropTypeId)
                {
                    case ServicePropTypeEnum.SelectType:
                        isValid = CanConvert(serviceProp.PermissibleValue, typeof(Array));
                        break;
                    case ServicePropTypeEnum.ArrayType:
                        isValid = CanConvert(serviceProp.PermissibleValue, typeof(Array));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (!isValid) return false;
            }
            return true;
        }

        private bool CanConvert(string value, Type type)
        {
            var converter = TypeDescriptor.GetConverter(type);
            return converter.IsValid(value);
        }
    }
}