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
    public abstract class ClientEntityTypeConfigurationBase<T>
        : EntityTypeConfigurationBase<T>
        where T : Client
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
        }
    }
}
