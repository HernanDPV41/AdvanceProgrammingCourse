using CarDealer.Application.Abstract;
using CarDealer.Contracts;
using CarDealer.Contracts.Vehicles;
using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Vehicles.Queries.GetMotorcycleById
{
    public class GetMotorcycleByIdQueryHandler
        : IQueryHandler<GetMotorcycleByIdQuery, Motorcycle?>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetMotorcycleByIdQueryHandler(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Task<Motorcycle?> Handle(GetMotorcycleByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_vehicleRepository.GetVehicleById<Motorcycle>(request.Id));
        }
    }
}
