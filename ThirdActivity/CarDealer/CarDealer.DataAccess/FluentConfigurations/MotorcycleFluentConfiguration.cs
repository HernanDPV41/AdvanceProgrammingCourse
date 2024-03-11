using CarDealer.Domain.Entities.Clients;
using CarDealer.Domain.Entities.Common;
using CarDealer.Domain.Entities.Orders;
using CarDealer.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.FluentConfigurations
{
    /// <summary>
    /// Define las configuraciones de un <see cref="Motorcycle"/> para EntityFramework.
    /// </summary> 

    internal class MotorcycleFluentConfiguration : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.ToTable("Motorcycles");
            builder.HasBaseType<Vehicle>();
        }
    }
}
