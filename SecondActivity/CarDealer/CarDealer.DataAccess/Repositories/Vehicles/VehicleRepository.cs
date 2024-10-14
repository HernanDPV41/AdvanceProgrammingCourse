using CarDealer.Contracts.Vehicles;
using CarDealer.DataAccess.Contexts;
using CarDealer.DataAccess.Repositories.Common;
using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Repositories.Vehicles
{
    /// <summary>
    /// Implementación del repositorio <see cref="IVehicleRepository"/>.
    /// </summary>
    public class VehicleRepository
        : RepositoryBase, IVehicleRepository
    {
        public VehicleRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
        }

        public IEnumerable<T> GetAllVehicles<T>() where T : Vehicle
        {
            return _context.Set<T>().ToList();
        }

        public T? GetVehicleById<T>(Guid id) where T : Vehicle
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
        }
    }
}
