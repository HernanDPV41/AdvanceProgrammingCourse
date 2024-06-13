using CarDealer.Domain.Entities.Clients;
using CarDealer.Domain.Entities.Orders;
using CarDealer.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;
using System.Drawing;
using CarDealer.DataAccess.FluentConfigurations;
using Microsoft.Data.Sqlite;
using CarDealer.DataAccess.FluentConfigurations.Clients;
using CarDealer.DataAccess.FluentConfigurations.Orders;
using CarDealer.DataAccess.FluentConfigurations.Vehicles;

namespace CarDealer.DataAccess.Contexts
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
        public DbSet<Client> Clients { get; set; }
        /// <summary>
        /// Tabla de órdenes de compra.
        /// </summary>
        public DbSet<BuyOrder> BuyOrders { get; set; }
        /// <summary>
        /// Tabla de vehículos.
        /// </summary>
        public DbSet<Vehicle> Vehicles { get; set; }

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

            modelBuilder.ApplyConfiguration(new EnterpriseClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PrivateClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BuyOrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CarEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MotorcycleEntityTypeConfiguration());
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
                var connectionString ="Data Source = CarDealerDB.sqlite";
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
