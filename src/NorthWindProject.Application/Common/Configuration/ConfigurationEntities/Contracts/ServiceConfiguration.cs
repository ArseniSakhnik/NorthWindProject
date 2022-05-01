using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.Core.Entities.Contracts.BaseContract;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Contracts
{
    public abstract class ServiceConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : Contract
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.Ignore(contract => contract.GetNameAndValuesDictionary);
        }
    }
}