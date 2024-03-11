using CarDealer.Domain.Entities.Common;
using CarDealer.Domain.Entities.Types;
using CarDealer.Domain.Entities.Vehicles;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Abstract.Vehicles
{
    /// <summary>
    /// Define las operaciones a realizar en BD sobre vehículos.
    /// </summary>
    public interface IVehicleRepository : IRepository
    {
        /// <summary>
        /// Crea un automóvil en BD.
        /// </summary>
        /// <param name="brand">Marca del auto.</param>
        /// <param name="energySource">Fuente de energía del auto.</param>
        /// <param name="price">Precio del auto.</param>
        /// <returns>Automóvil creado en BD.</returns>
        Car CreateCar(string brand, EnergySource energySource, Price price);

        /// <summary>
        /// Crea una motocicleta en BD.
        /// </summary>
        /// <param name="brand">Marca de la moto.</param>
        /// <param name="energySource">Fuente de energía de la moto.</param>
        /// <param name="price">Precio de la moto.</param>
        /// <returns>Moto creada en BD.</returns>
        Motorcycle CreateMotorcycle(string brand, EnergySource energySource, Price price);

        /// <summary>
        /// Obtiene un vehículo de BD.
        /// </summary>
        /// <typeparam name="T">Tipo de vehículo a obtener.</typeparam>
        /// <param name="id">Identificador del vehículo.</param>
        /// <returns>Vehículo solicitado de existir en BD, de lo contrario <see langword="null"/></returns>
        T? Get<T>(int id) where T : Car;

        /// <summary>
        /// Actualiza un vehículo en BD.
        /// </summary>
        /// <param name="vehicle">Vehículo a actualizar.</param>
        void Update(Vehicle vehicle);

        /// <summary>
        /// Elimina un vehículo en BD.
        /// </summary>
        /// <param name="id">Identificador del vehículo a eliminar.</param>
        void Delete(int id);
    }
}
