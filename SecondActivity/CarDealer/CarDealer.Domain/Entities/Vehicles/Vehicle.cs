using CarDealer.Domain.Abstract;
using CarDealer.Domain.Entities.Common;
using CarDealer.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Domain.Entities.Vehicles
{
    /// <summary>
    /// Clase base para los vehículos del concesionario.
    /// </summary>
    public abstract class Vehicle : IBrand
    {
        #region Properties
        /// <summary>
        /// Identificador en el soporte de datos.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }
        /// <summary>
        /// Fuente de energía que consume el automóvil.
        /// </summary>
        public EnergySource EnergySource { get; }

        public string Brand { get; }

        /// <summary>
        /// Precio del vehículo.
        /// </summary>
        public Price Price { get; set; }

        /// <summary>
        /// Existencias del vehículo en la tienda.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Color del vehículo.
        /// </summary>
        public Color Color { get; set; }

        #endregion

        /// <summary>
        /// Inicializa un objeto <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="brand">Marca del vehículo.</param>
        /// <param name="energySource">Fuente de energía del vehículo.</param>
        /// <param name="price">Precio del vehículo.</param>
        public Vehicle(string brand, EnergySource energySource)
        {
            Stock = 0;
            Price = new Price(MoneyType.MN, 0);
            Color = Color.Black;
            Brand = brand;
            EnergySource = energySource;
        }
    }
}
