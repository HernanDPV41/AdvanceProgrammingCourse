using CarDealer.Application.Abstract;
using CarDealer.Contracts;
using CarDealer.Contracts.Vehicles;
using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Application.Vehicles.Queries.GetAllMotorcycles
{
    public class GetAllMotorcyclesQueryHandler
        : IQueryHandler<GetAllMotorcyclesQuery, IEnumerable<Motorcycle>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        
        public GetAllMotorcyclesQueryHandler(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Task<IEnumerable<Motorcycle>> Handle(GetAllMotorcyclesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_vehicleRepository.GetAllVehicles<Motorcycle>());
        }
    }
}
