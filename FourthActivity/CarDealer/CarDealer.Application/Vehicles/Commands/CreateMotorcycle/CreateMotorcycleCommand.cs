using CarDealer.Application.Abstract;
using CarDealer.Domain.Entities.Vehicles;
using CarDealer.Domain.Types;
using CarDealer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Vehicles.Commands.CreateMotorcycle
{
    public record CreateMotorcycleCommand(
        string Brand,
        EnergySource EnergySource,
        Price Price) : ICommand<Motorcycle>;
    
}
