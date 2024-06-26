using CarDealer.DataAccess;
using CarDealer.DataAccess.Contexts;
using CarDealer.Domain.Common;
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
        static async Task Main(string[] args)
        {
            //Borrando BD en caso de existir una antigua,
            // esto se hace pq para que este programa en particular
            // funcione correctamente, debe iniciar con la BD vacía.
            if (File.Exists("Data.sqlite"))
                File.Delete("Data.sqlite");

            // Definiendo string de conexión.
            string connectionString = "Data Source = Data.sqlite";

            // Creando contexto a usar por repositorios.
            ApplicationContext context = new ApplicationContext(connectionString);

            //Generando la Bd en caso de no existir
            if (!context.Database.CanConnect())
                context.Database.Migrate();

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

            // ***************Almacenando entidades en BD.
            context.Vehicles.Add(car1);
            context.Vehicles.Add(car2);
            context.Vehicles.Add(motorcycle);

            context.Clients.Add(privateClient);
            context.Clients.Add(enterpriseClient);

            context.BuyOrders.Add(buyOrder1);
            context.BuyOrders.Add(buyOrder2);
            context.BuyOrders.Add(buyOrder3);

            // Es necesario guardar los cambios para que se actualice la BD.
            context.SaveChanges();

            // ******************Obteniendo entidades relacionadas a una orden de compra.
            Car? carFromOrder = context
                .Set<Car>()
                .FirstOrDefault(v => v.Id == buyOrder1.VehicleId);
            PrivateClient? clientFromOrder = context
                .Set<PrivateClient>()
                .FirstOrDefault(c => c.Id == buyOrder1.ClientId);

            if (carFromOrder is null || clientFromOrder is null)
                Console.WriteLine("Las entidades de la orden 1 no se encontraron en BD.");
            else
            {
                Console.WriteLine($"La orden 1 comprende una compra de {buyOrder1.Units} vehículo(s) de marca" +
                    $" {carFromOrder.Brand} por el cliente {clientFromOrder.Name}.");
            }
            // Las operaciones de lectura no requieren que se guarden los cambios, ya que ellas no modifican
            // a las entidades en BD.


            // **************Modificando la cantidad de existencias de la motocicleta.
            motorcycle.Stock = 25;

            context.Vehicles.Update(motorcycle);
            context.SaveChanges();

            Motorcycle? modifiedMotorcycle = context
                .Set<Motorcycle>()
                .FirstOrDefault(m => m.Id == motorcycle.Id);
            Console.WriteLine($"Nueva cantidad de motocicletas {modifiedMotorcycle.Stock}");

            // **************Eliminando un cliente.
            context.Clients.Remove(enterpriseClient);
            context.SaveChanges();

            EnterpriseClient? deletedClient = context
                .Set<EnterpriseClient>()
                .FirstOrDefault(c => c.Id == enterpriseClient.Id);
            if (deletedClient is null)
                Console.WriteLine("Client successfully deleted.");
        }

    }
}