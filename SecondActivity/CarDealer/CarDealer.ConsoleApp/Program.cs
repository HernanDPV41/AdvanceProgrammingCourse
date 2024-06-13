using CarDealer.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealer.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //// Creando un contexto para interactuar con la Base de datos.
            //ApplicationContext appContext = new ApplicationContext("Data Source=CarDealerDB.sqlite");
            //// Verificando si la BD no existe
            //if(!appContext.Database.CanConnect())
            //{
            //    // Migrando base de datos. Este paso genera la BD con las tablas configuradas en su migración.
            //    appContext.Database.Migrate();
            //}

            //************ Create
            //Price carPrice = new Price(MoneyType.Euro, 4500);

            //appContext.Set<Price>().Add(carPrice);
            //appContext.SaveChanges();

            //Car car = new Car("Peugeot", EnergySource.Petroleum, carPrice);

            //appContext.Set<Car>().Add(car);
            //appContext.SaveChanges();

            //*************** Get
            //var cars = appContext.Set<Car>().ToList();

            //foreach (var loadedCar in cars)
            //{
            //    Price? price = appContext.Set<Price>().Find(loadedCar.PriceId);
            //    if (price is null)
            //        throw new InvalidOperationException($"Cannot find price with Id {loadedCar.PriceId}.");
            //    loadedCar.Price = price;
            //}

            //**************** Update
            //var cars = appContext.Set<Car>().ToList();

            //foreach (var loadedCar in cars)
            //{
            //    loadedCar.IsDescapotable = false;
            //    appContext.Set<Car>().Update(loadedCar);
            //}

            //appContext.SaveChanges();

            //***************** Delete
            //var cars = appContext.Set<Car>().ToList();

            //foreach (var loadedCar in cars)
            //{
            //    appContext.Set<Car>().Remove(loadedCar);
            //}
            //appContext.SaveChanges();


        }

    }
}