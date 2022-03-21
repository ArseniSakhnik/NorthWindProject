using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Test;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.Ignore(v => v.IgnoreValue);
        }
    }
}