using CarDealer.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.FluentConfigurations.Vehicles
{
    public class MotorcycleEntityTypeConfiguration
        : VehicleEntityTypeConfigurationBase<Motorcycle>
    {
        public override void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.ToTable("Motorcycles");
            base.Configure(builder);
        }
    }
}
