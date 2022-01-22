using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Service;
using NorthWindProject.Application.Enums;

namespace NorthWindProject.Application.Common.Configuration.ServiceConfiguration
{
    public class FieldsTypeServiceConfiguration : IEntityTypeConfiguration<FieldTypeService>
    {
        public void Configure(EntityTypeBuilder<FieldTypeService> builder)
        {
            builder.HasData(new List<FieldTypeService>
            {
                new FieldTypeService
                {
                    Id = FieldServiceTypeEnum.Text,
                    Name = "Строковое поле",
                    Description = "Поле будет поддерживать строковые значения"
                },
                new FieldTypeService
                {
                    Id = FieldServiceTypeEnum.Number,
                    Name = "Числовое поле",
                    Description = "Поле будет поддерживать числовые значения"
                },
                new FieldTypeService
                {
                    Id = FieldServiceTypeEnum.Day,
                    Name = "Поле с днем",
                    Description = "Поле будет поддерживать ввод дня"
                },
                new FieldTypeService
                {
                    Id = FieldServiceTypeEnum.Month,
                    Name = "Поле месяца",
                    Description = "Поле обудет поддерживать ввод месяца"
                },
                new FieldTypeService
                {
                    Id = FieldServiceTypeEnum.Year,
                    Name = "Поле с годом",
                    Description = "Поле будет поддерживать ввод года"
                },
                new FieldTypeService
                {
                    Id = FieldServiceTypeEnum.Date,
                    Name = "Поле с общей датой",
                    Description = "Поле объединяет значения из дня, месяца и года"
                }
            });
        }
    }
}