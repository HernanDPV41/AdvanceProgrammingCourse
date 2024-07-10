using CarDealer.DataAccess.FluentConfigurations.Common;
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
    public class EnterpriseClientEntityTypeConfiguration
        : IEntityTypeConfiguration<EnterpriseClient>
    {
        public void Configure(EntityTypeBuilder<EnterpriseClient> builder)
        {
            builder.ToTable("EnterpriseClients");
            builder.HasBaseType(typeof(Client));
            builder.OwnsOne(x => x.Location);
        }
    }
}
