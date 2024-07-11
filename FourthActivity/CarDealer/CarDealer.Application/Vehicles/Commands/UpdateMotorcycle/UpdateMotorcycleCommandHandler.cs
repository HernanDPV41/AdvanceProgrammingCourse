using CarDealer.Application.Abstract;
using CarDealer.Contracts;
using CarDealer.Contracts.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Vehicles.Commands.UpdateMotorcycle
{
    public class UpdateMotorcycleCommandHandler
        : ICommandHandler<UpdateMotorcycleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMotorcycleCommandHandler(
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            _vehicleRepository.UpdateVehicle(request.Motorcycle);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
