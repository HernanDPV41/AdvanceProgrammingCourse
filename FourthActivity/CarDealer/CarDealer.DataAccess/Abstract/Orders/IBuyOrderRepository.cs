using CarDealer.Domain.Entities.Clients;
using CarDealer.Domain.Entities.Orders;
using CarDealer.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Abstract.Orders
{
    /// <summary>
    /// Define las operaciones a realizar en BD con ordenes de compra.
    /// </summary>
    public interface IBuyOrderRepository : IRepository
    {
        /// <summary>
        /// Crea una orden de compra en BD.
        /// </summary>
        /// <param name="client">Cliente asociado a la orden.</param>
        /// <param name="vehicle">Vehículo asociado a la orden.</param>
        /// <param name="units">Cantidad de unidades a comprar.</param>
        /// <returns>Orden creada en BD.</returns>
        BuyOrder Create(Client client, Vehicle vehicle, int units = 1);

        /// <summary>
        /// Obtiene una orden de compra de BD.
        /// </summary>
        /// <param name="id">Identificador de la orden a obtener.</param>
        /// <returns>Orden de compra solicitada de existir en BD, de lo contrario <see langword="null"/>.</returns>
        BuyOrder? Get(int id);

        /// <summary>
        /// Obtiene todas las ordenes de compra asociadas a un cliente en BD.
        /// </summary>
        /// <param name="client">Cliente asociado a las ordenes.</param>
        /// <returns>Colección de ordenes asociadas al cliente suministrado.</returns>
        IEnumerable<BuyOrder> GetByClient(Client client);

        /// <summary>
        /// Obtiene todas las ordenes de compra asociadas a un vehículo en BD.
        /// </summary>
        /// <param name="vehicle">Vehículo asociado a las ordenes.</param>
        /// <returns>Colección de ordenes asociadas al vehículo suministrado.</returns>
        IEnumerable<BuyOrder> GetByVehicle(Vehicle vehicle);

        /// <summary>
        /// Elimina una orden de compra en BD.
        /// </summary>
        /// <param name="order">Orden de compra a eliminar.</param>
        void Delete(BuyOrder order);
    }
}
