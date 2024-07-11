using CarDealer.Application.Abstract;
using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Vehicles.Queries.GetAllMotorcycles
{
    public record GetAllMotorcyclesQuery : IQuery<IEnumerable<Motorcycle>>;
    
}
