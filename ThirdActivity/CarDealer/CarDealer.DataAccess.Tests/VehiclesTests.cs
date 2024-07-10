using CarDealer.Contracts;
using CarDealer.Contracts.Vehicles;
using CarDealer.DataAccess.Contexts;
using CarDealer.DataAccess.Repositories.Vehicles;
using CarDealer.DataAccess.Tests.Utilities;
using CarDealer.Domain.Abstract;
using CarDealer.Domain.Entities.Vehicles;
using CarDealer.Domain.Types;
using CarDealer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Tests
{
    [TestClass]
    public class VehiclesTests
    {

        private IVehicleRepository _vehicleRepository;

        private IUnitOfWork _unitOfWork;


        public VehiclesTests()
        {
            ApplicationContext context = 
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _vehicleRepository = new VehicleRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("Mercedez", EnergySource.Petroleum,MoneyType.MLC, 5000)]
        [DataRow("Ferrari", EnergySource.Gasoline,MoneyType.MLC, 50000)]
        [TestMethod]
        public void Can_Add_Car(
            string brand,
            EnergySource energySource,
            MoneyType moneyType,
            double priceValue)
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Car car = new Car(
                id,
                brand,
                energySource,
                new Price(moneyType, priceValue));

            // Execute
            _vehicleRepository.AddVehicle(car);
            _unitOfWork.SaveChanges();

            // Assert
            Car? loadedCar = _vehicleRepository.GetVehicleById<Car>(id);
            Assert.IsNotNull(loadedCar);
        }

        [DataRow("Honda", EnergySource.Petroleum, MoneyType.MLC, 5000)]
        [DataRow("Ducatti", EnergySource.Gasoline, MoneyType.MLC, 50000)]
        [TestMethod]
        public void Can_Add_Motorcycle(
            string brand,
            EnergySource energySource,
            MoneyType moneyType,
            double priceValue)
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Motorcycle motorcycle = new Motorcycle(
                id,
                brand,
                energySource,
                new Price(moneyType, priceValue));

            // Execute
            _vehicleRepository.AddVehicle(motorcycle);
            _unitOfWork.SaveChanges();

            // Assert
            Motorcycle? loadedMotorcycle = _vehicleRepository.GetVehicleById<Motorcycle>(id);
            Assert.IsNotNull(loadedMotorcycle);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Car_By_Id(int position)
        {
            // Arrange
            var cars = _vehicleRepository.GetAllVehicles<Car>().ToList();
            Assert.IsNotNull(cars);
            Assert.IsTrue(position < cars.Count);
            Car carToGet = cars[position];

            // Execute
            Car? loadedCar = _vehicleRepository.GetVehicleById<Car>(carToGet.Id);

            // Assert
            Assert.IsNotNull(loadedCar);
        }

        [DataRow(1)]
        [TestMethod]
        public void Can_Get_Motorcycle_By_Id(int position)
        {
            // Arrange
            var motorcycle = _vehicleRepository.GetAllVehicles<Motorcycle>().ToList();
            Assert.IsNotNull(motorcycle);
            Assert.IsTrue(position < motorcycle.Count);
            Motorcycle motorcycleToGet = motorcycle[position];

            // Execute
            Motorcycle? loadedMotorcycle = _vehicleRepository.GetVehicleById<Motorcycle>(motorcycleToGet.Id);

            // Assert
            Assert.IsNotNull(loadedMotorcycle);
        }

        [TestMethod]
        public void Cannot_Get_Car_By_Invalid_Id()
        {
            // Arrange
            
            // Execute
            Car? loadedCar = _vehicleRepository.GetVehicleById<Car>(Guid.Empty);

            // Assert
            Assert.IsNull(loadedCar);
        }

        [TestMethod]
        public void Cannot_Get_Motorcycle_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Motorcycle? loadedMotorcycle = _vehicleRepository.GetVehicleById<Motorcycle>(Guid.Empty);

            // Assert
            Assert.IsNull(loadedMotorcycle);
        }

        [DataRow(0,false, false, 4)]
        [TestMethod]
        public void Can_Update_Car(int position ,bool isAutonomous, bool isDescapotable, int passengerCapacity)
        {
            // Arrange
            var cars = _vehicleRepository.GetAllVehicles<Car>().ToList();
            Assert.IsNotNull(cars);
            Assert.IsTrue(position < cars.Count);
            Car carToUpdate = cars[position];

            // Execute
            carToUpdate.IsAutonomous = isAutonomous;
            carToUpdate.IsDescapotable = isDescapotable;
            carToUpdate.PassengerCapacity = passengerCapacity;
            _vehicleRepository.UpdateVehicle(carToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Car? loadedCar = _vehicleRepository.GetVehicleById<Car>(carToUpdate.Id);
            Assert.IsNotNull(loadedCar);
            Assert.AreEqual(loadedCar.IsAutonomous,isAutonomous);
            Assert.AreEqual(loadedCar.IsDescapotable,isDescapotable);
            Assert.AreEqual(loadedCar.PassengerCapacity,passengerCapacity);
        }

        [DataRow(0, false)]
        [TestMethod]
        public void Can_Update_Motorcycle(int position, bool hasSideCar)
        {
            // Arrange
            var motorcycles = _vehicleRepository.GetAllVehicles<Motorcycle>().ToList();
            Assert.IsNotNull(motorcycles);
            Assert.IsTrue(position < motorcycles.Count);
            Motorcycle motorcycleToUpdate = motorcycles[position];

            // Execute
            motorcycleToUpdate.HasSideCar = hasSideCar;
            _vehicleRepository.UpdateVehicle(motorcycleToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Motorcycle? loadedMotorcycle = _vehicleRepository.GetVehicleById<Motorcycle>(motorcycleToUpdate.Id);
            Assert.IsNotNull(loadedMotorcycle);
            Assert.AreEqual(loadedMotorcycle.HasSideCar, hasSideCar);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Car(int position)
        {
            // Arrange
            var cars = _vehicleRepository.GetAllVehicles<Car>().ToList();
            Assert.IsNotNull(cars);
            Assert.IsTrue(position < cars.Count);
            Car carToDelete = cars[position];

            // Execute
            _vehicleRepository.DeleteVehicle(carToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Car? loadedCar = _vehicleRepository.GetVehicleById<Car>(carToDelete.Id);
            Assert.IsNull(loadedCar);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Motorcycle(int position)
        {
            // Arrange
            var motorcycles = _vehicleRepository.GetAllVehicles<Motorcycle>().ToList();
            Assert.IsNotNull(motorcycles);
            Assert.IsTrue(position < motorcycles.Count);
            Motorcycle motorcycleToDelete = motorcycles[position];

            // Execute
            _vehicleRepository.DeleteVehicle(motorcycleToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Motorcycle? loadedMotorcycle = _vehicleRepository.GetVehicleById<Motorcycle>(motorcycleToDelete.Id);
            Assert.IsNull(loadedMotorcycle);
        }

    }
}
