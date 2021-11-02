using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NorthWindProject.Application.Entities.Service;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace NorthWindProject.Application.Features.Services.Commands
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Необходимо ввести имя сервиса");
            
            RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Необходимо ввести описание сервиса");
        }
    }
}