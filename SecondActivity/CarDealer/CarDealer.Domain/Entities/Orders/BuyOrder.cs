using CarDealer.Domain.Entities.Clients;
using CarDealer.Domain.Entities.Common;
using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Domain.Entities.Orders
{
    /// <summary>
    /// Orden de compra.
    /// </summary>
    public class BuyOrder : Entity
    {

        #region Properties

        /// <summary>
        /// Cliente que realizó la compra.
        /// </summary>
        [NotMapped]
        public Client Client { get; set; }

        /// <summary>
        /// Identificador del cliente en el soporte de datos.
        /// </summary>
        public int ClientId { get; protected set; }

        /// <summary>
        /// Vehículo a comprar. 
        /// </summary>
        [NotMapped]
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Identificador del vehículo en el soporte de datos.
        /// </summary>
        public int VehicleId { get; protected set; }

        /// <summary>
        /// Cantidad de unidades del vehículo compradas.
        /// </summary>
        public int Units { get; set; }

        /// <summary>
        /// Fecha de creación de la orden.
        /// </summary>
        public DateTime CreationDate { get; set; }
        
        /// <summary>
        /// Fecha en la que se ejecuta el pago.
        /// </summary>
        public DateTime? PaymentDay { get; set; }

        /// <summary>
        /// Indica si la orden de compra ya fue pagada;
        /// </summary>
        [NotMapped]
        public bool IsPayed => PaymentDay is not null;

        /// <summary>
        /// Precio total a pagar por la orden.
        /// </summary>
        [NotMapped]
        public Price TotalPrice => new Price(Vehicle.Price.Currency, Vehicle.Price.Value * Units);

        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected BuyOrder() { }

        /// <summary>
        /// Inicializa un objeto <see cref="BuyOrder"/>.
        /// </summary>
        /// <param name="client">Cliente que realiza la compra.</param>
        /// <param name="vehicle">Vehículo que realiza la compra.</param>
        /// <param name="units">Unidades del vehículo compradas.</param>
        public BuyOrder(Client client, Vehicle vehicle, int units = 1)
        {
            Client = client;
            ClientId = client.Id;
            Vehicle = vehicle;
            VehicleId = vehicle.Id;
            Units = units;
        }

    }
}
