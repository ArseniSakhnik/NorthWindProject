using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using NorthWindProject.Application.Entities.Services.BaseService;
using NorthWindProject.Application.Entities.Services.VacuumTruckYurService;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Services.VacuumTruckService
{
    public class
        VacuumTruckFizServiceConfiguration : IEntityTypeConfiguration<
            VacuumTruckServiceYur>
    {
        
        
        public void Configure(EntityTypeBuilder<VacuumTruckServiceYur> builder)
        {
            
        }
    }
}