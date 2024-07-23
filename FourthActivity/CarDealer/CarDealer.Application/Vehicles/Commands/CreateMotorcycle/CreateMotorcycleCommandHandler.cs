using CarDealer.Application.Abstract;
using CarDealer.Contracts;
using CarDealer.Contracts.Vehicles;
using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Vehicles.Commands.CreateMotorcycle
{
    public class CreateMotorcycleCommandHandler
        : ICommandHandler<CreateMotorcycleCommand, Motorcycle>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMotorcycleCommandHandler(
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Motorcycle> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            Motorcycle result = new Motorcycle(
                Guid.NewGuid(),
                request.Brand,
                request.EnergySource,
                request.Price);

            _vehicleRepository.AddVehicle(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
