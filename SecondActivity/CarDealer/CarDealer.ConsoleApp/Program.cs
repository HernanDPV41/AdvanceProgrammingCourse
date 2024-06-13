using CarDealer.Contracts;
using CarDealer.Contracts.Clients;
using CarDealer.Contracts.Orders;
using CarDealer.Contracts.Vehicles;
using CarDealer.DataAccess;
using CarDealer.DataAccess.Contexts;
using CarDealer.DataAccess.Repositories.Clients;
using CarDealer.DataAccess.Repositories.Orders;
using CarDealer.DataAccess.Repositories.Vehicles;
using CarDealer.Domain.Entities.Clients;
using CarDealer.Domain.Entities.Orders;
using CarDealer.Domain.Entities.Vehicles;
using CarDealer.Domain.Types;
using CarDealer.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Definiendo string de conexión.
            string connectionString = "Data Source = Data.sqlite";

            // Creando contexto a usar por repositorios.
            ApplicationContext context = new ApplicationContext(connectionString);

            // Creando instancias de repositorios y de UnitOfWork.
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            IClientRepository clientRepository = new ClientRepository(context);
            IVehicleRepository vehicleRepository = new VehicleRepository(context);
            IBuyOrderRepository buyOrderRepository = new BuyOrderRepository(context);

            // Creando entidades para probar BD.
            Car car1 = new Car(
                Guid.NewGuid(), 
                "Toyota",
                EnergySource.Gasoline, 
                new Price( MoneyType.MLC, 5000));
            Car car2 = new Car(
                Guid.NewGuid(),
                "Mercedes Benz",
                EnergySource.Petroleum,
                new Price(MoneyType.MLC, 10000));
            Motorcycle motorcycle = new Motorcycle(
                Guid.NewGuid(),
                "Honda",
                EnergySource.Gasoline,
                new Price(MoneyType.MN, 45000));
            PrivateClient privateClient = new PrivateClient(
                Guid.NewGuid(),
                "97854628415",
                "Pedro",
                18);
            EnterpriseClient enterpriseClient = new EnterpriseClient(
                Guid.NewGuid(),
                "Etecsa S.A.",
                new PhysicalLocation("Cuba","Habana","Obispo #687"));
            BuyOrder buyOrder1 = new BuyOrder(
                Guid.NewGuid(),
                privateClient,
                car1,
                1);
            BuyOrder buyOrder2 = new BuyOrder(
                Guid.NewGuid(),
                enterpriseClient,
                motorcycle,
                20);
            BuyOrder buyOrder3 = new BuyOrder(
                Guid.NewGuid(),
                enterpriseClient,
                car2,
                15);

            // Almacenando entidades en BD.
        }

    }
}