using CarDealer.Domain.Types;
using CarDealer.Domain.ValueObjects;

namespace CarDealer.Domain.Entities.Vehicles
{
    /// <summary>
    /// Automóvil.
    /// </summary>
    public class Car : Vehicle
    {
        #region Properties

        /// <summary>
        /// Indica si el auto tiene manejo autónomo.
        /// </summary>
        public bool IsAutonome { get; set; }

        /// <summary>
        /// Indica si el automóvil es descapotable.
        /// </summary>
        public bool IsDescapotable { get; set; }

        /// <summary>
        /// Capacidad de pasajeros.
        /// </summary>
        public int PassengerCapacity { get; set; }

        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Car() { }

        /// <summary>
        /// Inicializa un objeto <see cref="Car"/>.
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <param name="brand">Marca del automóvil.</param>
        /// <param name="energySource">Fuente de energía del automóvil.</param>
        /// <param name="price">Precio del automóvil.</param>
        public Car(
            Guid id, 
            string brand, 
            EnergySource energySource, 
            Price price) 
            : base(id, brand, energySource, price)
        {
            IsAutonome = true;
            IsDescapotable = true;
            PassengerCapacity = 4;
        }
    }
}
