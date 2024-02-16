﻿using CarDealer.Domain.Entities.Clients;
using CarDealer.Domain.Entities.Common;
using CarDealer.Domain.Entities.Orders;
using CarDealer.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;
using System.Drawing;
using CarDealer.DataAccess.FluentConfigurations;

namespace CarDealer.DataAccess.Concrete
{
    /// <summary>
    /// Define la estructura de la base de datos de la aplicación.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        //Región destinada a la declaración de las tablas de las entidades base
        #region Tables 

        /// <summary>
        /// Tabla de clientes.
        /// </summary>
        DbSet<Client> Clients { get; set; }
        /// <summary>
        /// Tabla de ubicación geográfica de una entidad.
        /// </summary>
        DbSet<PhysicalLocation> PhysicalLocations { get; set; }
        /// <summary>
        /// Tabla de precios.
        /// </summary>
        DbSet<Price> Prices { get; set; }
        /// <summary>
        /// Tabla de órdenes de compra.
        /// </summary>
        DbSet<BuyOrder> BuyOrders { get; set; }
        /// <summary>
        /// Tabla de vehículos.
        /// </summary>
        DbSet<Vehicle> Vehicles { get; set; }
        #endregion


        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        public ApplicationContext()
        {
        }

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="connectionString">
        /// Cadena de conexión.
        /// </param>
        public ApplicationContext(string connectionString)
            : base(GetOptions(connectionString))
        {
        }

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="options">
        /// Opciones del contexto.
        /// </param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Abstract classes mapping

            modelBuilder.Entity<Client>().ToTable("Client");

            modelBuilder.Entity<PhysicalLocation>().ToTable("PhysicalLocations");

            modelBuilder.Entity<Price>().ToTable("Prices");

            modelBuilder.Entity<BuyOrder>().ToTable("BuyOrders");

            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
            modelBuilder.Entity<Vehicle>().Property(v => v.Color)
                .HasConversion(
                c => c.ToArgb(),
                c => Color.FromArgb(c));

            #endregion

            modelBuilder.ApplyConfiguration(new EnterpriseClientFluentConfiguration());
            modelBuilder.ApplyConfiguration(new PhysicalLocationFluentConfiguration());
            modelBuilder.ApplyConfiguration(new PrivateClientFluentConfiguration());
            modelBuilder.ApplyConfiguration(new PriceFluentConfiguration());
            modelBuilder.ApplyConfiguration(new BuyOrderFluentConfiguration());
            modelBuilder.ApplyConfiguration(new MotorcycleFluentConfiguration());
            modelBuilder.ApplyConfiguration(new CarFluentConfiguration());
        }


        #region Helpers

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }

        #endregion

    }

    /// <summary>
    /// Habilita características en tiempo de diseño de la base de datos de la aplicación.
    /// Ej: Migraciones.
    /// </summary>
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            try
            {
                //Es necesario declarar una variable de sistema cuyo nombre sea CarDealerDBPath y el valor será la carpeta donde se 
                //va a almacenar la base de datos.
                var connectionString = Environment.GetEnvironmentVariable("CarDealerDBPath", EnvironmentVariableTarget.Machine)
                    ?? throw new ArgumentNullException("CarDealerDBPath");
                optionsBuilder.UseSqlite(connectionString);
            }
            catch (Exception)
            {
                //handle errror here.. means DLL has no sattelite configuration file.
                throw;
            }

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
