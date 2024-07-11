using CarDealer.Application.Abstract;
using CarDealer.Contracts;
using CarDealer.Contracts.Vehicles;
using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Vehicles.Commands.DeleteMotorcycle
{
    public class DeleteMotorcycleCommandHandler
        : ICommandHandler<DeleteMotorcycleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMotorcycleCommandHandler(
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var motorcycleToDelete = _vehicleRepository.GetVehicleById<Motorcycle>(request.Id);
            if (motorcycleToDelete is null)
                return Task.CompletedTask;
            _vehicleRepository.DeleteVehicle(motorcycleToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
