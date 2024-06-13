using CarDealer.Domain.Abstract;
using CarDealer.Domain.Common;
using CarDealer.Domain.Types;
using CarDealer.Domain.ValueObjects;
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
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Vehicle() { }

        /// <summary>
        /// Inicializa un objeto <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <param name="brand">Marca del vehículo.</param>
        /// <param name="energySource">Fuente de energía del vehículo.</param>
        /// <param name="price">Precio del vehículo.</param>
        public Vehicle(
            Guid id, 
            string brand, 
            EnergySource energySource, 
            Price price)
            : base(id)
        {
            Stock = 0;
            Price = price;
            Color = Color.Black;
            Brand = brand;
            EnergySource = energySource;
        }
    }
}
