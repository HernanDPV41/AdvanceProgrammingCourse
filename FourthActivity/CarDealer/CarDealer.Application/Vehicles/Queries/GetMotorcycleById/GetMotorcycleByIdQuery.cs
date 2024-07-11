using CarDealer.Application.Abstract;
using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Vehicles.Queries.GetMotorcycleById
{
    public record GetMotorcycleByIdQuery(Guid Id) : IQuery<Motorcycle?>;
}
