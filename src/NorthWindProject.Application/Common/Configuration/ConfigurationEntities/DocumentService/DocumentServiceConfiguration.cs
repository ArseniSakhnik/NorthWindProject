using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using NorthWind.Core.Entities.Services.BaseService;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.DocumentService
{
    public class DocumentServiceConfiguration : IEntityTypeConfiguration<NorthWind.Core.Entities.Services.DocumentService.DocumentService>
    {
        public void Configure(EntityTypeBuilder<NorthWind.Core.Entities.Services.DocumentService.DocumentService> builder)
        {
            builder.Property(document => document.DocumentFields)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}),
                    v => JsonConvert.DeserializeObject<List<DocumentField>>(v,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore})
                );
        }
    }
}