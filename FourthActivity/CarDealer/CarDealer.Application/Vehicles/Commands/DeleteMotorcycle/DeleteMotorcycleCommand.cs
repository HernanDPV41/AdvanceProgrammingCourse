using CarDealer.Application.Abstract;

namespace CarDealer.Application.Vehicles.Commands.DeleteMotorcycle
{
    public record DeleteMotorcycleCommand(Guid Id) : ICommand;
}
