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
    public class BuyOrder
    {

        #region Properties
        /// <summary>
        /// Identificador en el soporte de datos.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuyOrderId { get; set; }

        /// <summary>
        /// Cliente que realizó la compra.
        /// </summary>
        public Client Client { get;}

        /// <summary>
        /// Vehículo a comprar. 
        /// </summary>
        public Vehicle Vehicle { get; }

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
        public bool IsPayed => PaymentDay is not null;

        /// <summary>
        /// Precio total a pagar por la orden.
        /// </summary>
        public Price TotalPrice => new Price(Vehicle.Price.Currency, Vehicle.Price.Value * Units);

        #endregion

        /// <summary>
        /// Inicializa un objeto <see cref="BuyOrder"/>.
        /// </summary>
        /// <param name="client">Cliente que realiza la compra.</param>
        /// <param name="vehicle">Vehículo que realiza la compra.</param>
        /// <param name="units">Unidades del vehículo compradas.</param>
        public BuyOrder(Client client, Vehicle vehicle, int units = 1)
        {
            Client = client;
            Vehicle = vehicle;
            Units = units;
        }

    }
}
