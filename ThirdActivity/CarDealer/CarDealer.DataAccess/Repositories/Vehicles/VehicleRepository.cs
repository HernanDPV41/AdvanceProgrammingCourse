using CarDealer.DataAccess.Abstract.Vehicles;
using CarDealer.Domain.Entities.Common;
using CarDealer.Domain.Entities.Types;
using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Repositories
{
    public partial class ApplicationRepository : IVehicleRepository
    {
        public Car CreateCar(string brand, EnergySource energySource, Price price)
        {
            Car car = new Car(brand, energySource, price);
            _context.Add(car);
            return car;
        }

        public Motorcycle CreateMotorcycle(string brand, EnergySource energySource, Price price)
        {
            Motorcycle motorcycle = new Motorcycle(brand, energySource, price);
            _context.Add(motorcycle);
            return motorcycle;
        }

        public void Delete(Vehicle vehicle)
        {
            _context.Remove(vehicle);
        }

        public T? GetVehicle<T>(int id) where T : Vehicle
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _context.Set<Vehicle>().ToList();
        }

        public void Update(Vehicle vehicle)
        {
            _context.Update(vehicle);
        }
    }
}
