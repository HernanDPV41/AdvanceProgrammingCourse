using CarDealer.DataAccess.Abstract.Common;
using CarDealer.DataAccess.Abstract.Vehicles;
using CarDealer.DataAccess.Repositories;
using CarDealer.DataAccess.Tests.Utilities;
using CarDealer.Domain.Entities.Common;
using CarDealer.Domain.Entities.Types;
using CarDealer.Domain.Entities.Vehicles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CarDealer.DataAccess.Tests
{
    [TestClass]
    public class VehicleTests
    {

        private IVehicleRepository _vehicleRepository;


        public VehicleTests()
        {
            _vehicleRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [TestMethod]
        [DataRow("Toyota", EnergySource.Petroleum, 2)]
        [DataRow("Porsche", EnergySource.Electricity, 2)]
        public void Can_Create_Car(string brand, EnergySource energySource, int priceId)
        {
            // Arrange
            _vehicleRepository.BeginTransaction();
            Price price = ((IPriceRepository)_vehicleRepository).Get(priceId);
            Assert.IsNotNull(price);

            // Execute

            var car = _vehicleRepository.CreateCar(brand, energySource, price);
            _vehicleRepository.PartialCommit();
            var loadedClar = _vehicleRepository.GetVehicle<Car>(car.Id);
            _vehicleRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedClar);
            Assert.AreEqual(loadedClar.Brand, car.Brand);
            Assert.AreEqual(loadedClar.EnergySource, car.EnergySource);
            Assert.AreEqual(loadedClar.PriceId, priceId);
        }

        [TestMethod]
        [DataRow("Toyota", EnergySource.Gasoline, 1)]
        [DataRow("Honda", EnergySource.Gasoline, 1)]
        public void Can_Create_Motocycle(string brand, EnergySource energySource, int priceId)
        {
            // Arrange
            _vehicleRepository.BeginTransaction();
            Price price = ((IPriceRepository)_vehicleRepository).Get(priceId);
            Assert.IsNotNull(price);

            // Execute

            var motorcycle = _vehicleRepository.CreateMotorcycle(brand, energySource, price);
            _vehicleRepository.PartialCommit();
            var loadedClar = _vehicleRepository.GetVehicle<Motorcycle>(motorcycle.Id);
            _vehicleRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedClar);
            Assert.AreEqual(loadedClar.Brand, motorcycle.Brand);
            Assert.AreEqual(loadedClar.EnergySource, motorcycle.EnergySource);
            Assert.AreEqual(loadedClar.PriceId, priceId);
        }

        [DataRow(4)]
        [TestMethod]
        public void Can_Get_Vehycles(int count)
        {
            //Arrange
            _vehicleRepository.BeginTransaction();

            //Execute
            var vehicles = _vehicleRepository.GetAllVehicles();
            _vehicleRepository.CommitTransaction();

            // Assert
            Assert.AreEqual(count, vehicles.Count());
        }

        [DataRow(0, 196, "red")]
        [DataRow(1, 15, "blue")]
        [DataRow(2, 348, "black")]
        [DataRow(3, 99, "red")]
        [TestMethod]
        public void Can_Update_Vehicle(int pos, int stock, string colorSting)
        {
            
            //Arrange
            Color color = Color.FromName(colorSting);
            _vehicleRepository.BeginTransaction();
            var vehicles = _vehicleRepository.GetAllVehicles();
            Assert.IsNotNull(vehicles);
            var vehicle = vehicles.ElementAt(pos);
            Assert.IsNotNull(vehicle);

            //Execute 
            vehicle.Stock = stock;
            vehicle.Color = color;
            _vehicleRepository.Update(vehicle);
            _vehicleRepository.PartialCommit();

            //Assert
            var updatedVehicle = _vehicleRepository.GetVehicle<Vehicle>(vehicle.Id);
            Assert.IsNotNull(updatedVehicle);
            Assert.AreEqual(updatedVehicle.Stock, vehicle.Stock);
            Assert.AreEqual(updatedVehicle.Color, vehicle.Color);

        }

        [DataRow(0, true)]
        [DataRow(1, false)]
        [TestMethod]
        public void Can_Update_Motocycle(int pos, bool hasSideCar)
        {

            //Arrange
            _vehicleRepository.BeginTransaction();
            var motorcycles = _vehicleRepository.GetAllVehicles().OfType<Motorcycle>().ToList();
            Assert.IsNotNull(motorcycles);
            var motorcycle = motorcycles.ElementAt(pos);
            Assert.IsNotNull(motorcycle);

            //Execute 
            motorcycle.HasSideCar = hasSideCar;
            _vehicleRepository.Update(motorcycle);
            _vehicleRepository.PartialCommit();

            //Assert
            var updatedCar = _vehicleRepository.GetVehicle<Motorcycle>(motorcycle.Id);
            Assert.IsNotNull(updatedCar);
            Assert.AreEqual(updatedCar.HasSideCar, motorcycle.HasSideCar);

        }
        [DataRow(0, true, false, 2)]
        [DataRow(1, false, true, 4)]
        [TestMethod]
        public void Can_Update_Car(int pos, bool isAutonome, bool isDescapotable, int passangerCapacity)
        {

            //Arrange
            _vehicleRepository.BeginTransaction();
            var cars = _vehicleRepository.GetAllVehicles().OfType<Car>().ToList();
            Assert.IsNotNull(cars);
            var car = cars.ElementAt(pos);
            Assert.IsNotNull(car);

            //Execute
            car.IsAutonome = isAutonome;
            car.IsDescapotable = isDescapotable;
            car.PassangerCapacity = passangerCapacity;
            _vehicleRepository.Update(car);
            _vehicleRepository.PartialCommit();

            //Assert
            var updatedCar = _vehicleRepository.GetVehicle<Car>(car.Id);
            Assert.IsNotNull(updatedCar);
            Assert.AreEqual(updatedCar.IsAutonome, car.IsAutonome);
            Assert.AreEqual(updatedCar.IsDescapotable, car.IsDescapotable);
            Assert.AreEqual(updatedCar.PassangerCapacity, car.PassangerCapacity);

        }



         
        [DataRow(2)]
        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Vehicle(int pos)
        {
            //Arrange
            _vehicleRepository.BeginTransaction();
            var vehicles = _vehicleRepository.GetAllVehicles();
            Assert.IsNotNull(vehicles);
            var count = vehicles.Count();
            var vehicle = vehicles.ElementAt(pos);
            Assert.IsNotNull(vehicle);

            //Execute 
            _vehicleRepository.Delete(vehicle);
            _vehicleRepository.PartialCommit();

            //Assert
            vehicles = _vehicleRepository.GetAllVehicles();
            Assert.AreEqual(count - 1, vehicles.Count());
            var deletedVehicle = _vehicleRepository.GetVehicle<Vehicle>(vehicle.Id);
            _vehicleRepository.CommitTransaction();
            Assert.IsNull(deletedVehicle);

        }



    }
}
