using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Contracts.Vehicles
{
    /// <summary>
    /// Describe las funcionalidades necesarias
    /// para dar persistencia a vehículos.
    /// </summary>s
    public interface IVehicleRepository
    {
        /// <summary>
        /// Añade un vehículo al soporte de datos.
        /// </summary>
        /// <param name="vehicle">Vehículo a añadir.</param>
        void AddVehicle(Vehicle vehicle);

        /// <summary>
        /// Obtiene un vehículo del soporte de datos a partir de su identificador.
        /// </summary>
        /// <typeparam name="T">Tipo de vehículo a obtener</typeparam>
        /// <param name="id">Identificador del vehículo.</param>
        /// <returns>Vehículo obtenido del soporte de datos; de no existir, <see langword="null"/>.</returns>
        T? GetVehicleById<T>(Guid id) where T : Vehicle;

        /// <summary>
        /// Obtiene todos los vehículos del soporte de datos.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAllVehicles<T>() where T : Vehicle;

        /// <summary>
        /// Actualiza el valor de un vehículo en el soporte de datos.
        /// </summary>
        /// <param name="vehicle">Instancia con la información a actualizar del vehículo.</param>
        void UpdateVehicle(Vehicle vehicle);

        /// <summary>
        /// Elimina un vehículo del soporte de datos
        /// </summary>
        /// <param name="vehicle">Vehículo a eliminar.</param>
        void DeleteVehicle(Vehicle vehicle);
        void DeleteVehicle(object carToDelete);
    }
}
