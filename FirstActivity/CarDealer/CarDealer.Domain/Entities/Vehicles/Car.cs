using CarDealer.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int PassangerCapacity { get; set; }

        #endregion

        /// <summary>
        /// Inicializa un objeto <see cref="Car"/>.
        /// </summary>
        /// <param name="brand">Marca del automóvil.</param>
        /// <param name="energySource">Fuente de energía del automóvil.</param>
        public Car(string brand, EnergySource energySource) : base(brand, energySource)
        {
            IsAutonome = true;
            IsDescapotable = true;
            PassangerCapacity = 4;
        }
    }
}
