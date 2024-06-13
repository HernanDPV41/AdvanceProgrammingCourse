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
    public class CarEntityTypeConfiguration
        : VehicleEntityTypeConfigurationBase<Car>
    {
        public override void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            base.Configure(builder);
        }
    }
}
