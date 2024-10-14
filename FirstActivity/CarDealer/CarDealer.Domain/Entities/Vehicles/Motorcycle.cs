using CarDealer.Domain.Types;
using CarDealer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Domain.Entities.Vehicles
{
    /// <summary>
    /// Motocicleta.
    /// </summary>
    public class Motorcycle : Vehicle
    {
        #region Properties
        
        /// <summary>
        /// Indica si la motocicleta tiene un SideCar.
        /// </summary>
        public bool HasSideCar { get; set; }

        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Motorcycle() { }
        /// <summary>
        /// Inicializa un objeto <see cref="Motorcycle"/>.
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <param name="brand">Marca de la motocicleta.</param>
        /// <param name="energySource">Fuente de energía de la motocicleta.</param>
        /// /// <param name="price">Precio de la motocicleta.</param>
        public Motorcycle(
            Guid id, 
            string brand, 
            EnergySource energySource, 
            Price price) 
            : base(id, brand, energySource, price)
        {
            HasSideCar = false;
        }
    }
}
