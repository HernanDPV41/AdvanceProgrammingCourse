using CarDealer.DataAccess.FluentConfigurations.Common;
using CarDealer.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.FluentConfigurations.Vehicles
{
    public class VehicleEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            // Definiendo conversión a string para la estructura color
            builder.Property(x => x.Color)
                .HasConversion(
                c => c.ToArgb(),
                s => Color.FromArgb(s));
            base.Configure(builder);
            builder.OwnsOne(x => x.Price);

        }
    }
}
