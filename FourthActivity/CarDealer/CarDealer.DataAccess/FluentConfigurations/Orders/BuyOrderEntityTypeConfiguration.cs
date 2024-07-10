using CarDealer.DataAccess.FluentConfigurations.Common;
using CarDealer.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.FluentConfigurations.Orders
{
    public class BuyOrderEntityTypeConfiguration
        :EntityTypeConfigurationBase<BuyOrder>
    {
        public override void Configure(EntityTypeBuilder<BuyOrder> builder)
        {
            builder.ToTable("BuyOrders");
            base.Configure(builder);
            builder.Ignore(x => x.IsPayed);
            builder.Ignore(x => x.TotalPrice);
            builder.HasOne(x => x.Client)
                .WithMany().HasForeignKey(x => x.ClientId);
            builder.HasOne(x => x.Vehicle)
                .WithMany().HasForeignKey(x => x.VehicleId);
        }
    }
}
