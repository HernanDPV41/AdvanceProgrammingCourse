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
    public abstract class Vehicle : Entity, IBrand
    {
        #region Properties

        /// <summary>
        /// Fuente de energía que consume el automóvil.
        /// </summary>
        public EnergySource EnergySource { get; protected set; }

        public string Brand { get; protected set; }

        /// <summary>
        /// Precio del vehículo.
        /// </summary>
        [NotMapped]
        public Price Price { get; set; }

        /// <summary>
        /// Identificador del precio en el soporte de datos.
        /// </summary>
        public int PriceId { get; protected set; }

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
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Vehicle() { }

        /// <summary>
        /// Inicializa un objeto <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="brand">Marca del vehículo.</param>
        /// <param name="energySource">Fuente de energía del vehículo.</param>
        /// <param name="price">Precio del vehículo.</param>
        public Vehicle(string brand, EnergySource energySource, Price price)
        {
            Stock = 0;
            Price = price;
            PriceId = price.Id;
            Color = Color.Black;
            Brand = brand;
            EnergySource = energySource;
        }
    }
}
