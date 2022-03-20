using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Services.BaseService;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Services
{
    public abstract class BaseServiceConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseService
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            
        }
    }
}