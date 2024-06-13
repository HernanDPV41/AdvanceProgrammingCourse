using CarDealer.Domain.Entities.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.FluentConfigurations.Clients
{
    public class PrivateClientEntityTypeConfiguration
        :ClientEntityTypeConfigurationBase<PrivateClient>
    {
        public override void Configure(EntityTypeBuilder<PrivateClient> builder)
        {
            builder.ToTable("PrivateClients");
            base.Configure(builder);

        }
    }
}
