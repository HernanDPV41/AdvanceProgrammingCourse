using CarDealer.Domain.Entities.Clients;
using CarDealer.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Contracts.Orders
{
    /// <summary>
    /// Describe las funcionalidades necesarias
    /// para dar persistencia a ordenes de compra.
    /// </summary>
    public interface IBuyOrderRepository
    {
        /// <summary>
        /// Añade una orden al soporte de datos.
        /// </summary>
        /// <param name="buyOrder">Orden a añadir.</param>
        void AddBuyOrder(BuyOrder buyOrder);

        /// <summary>
        /// Obtiene una orden del soporte de datos a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador de la orden.</param>
        /// <returns>Orden de compra obtenida del soporte de datos; de no existir, <see langword="null"/>.</returns>
        BuyOrder? GetBuyOrderById(Guid id);

        /// <summary>
        /// Actualiza el valor de una orden en el soporte de datos.
        /// </summary>
        /// <param name="buyOrder">Instancia con la información a actualizar de la orden.</param>
        void UpdateBuyOrder(BuyOrder buyOrder);

        /// <summary>
        /// Elimina un orden del soporte de datos.
        /// </summary>
        /// <param name="buyOrder">Orden a eliminar.</param>
        void DeleteBuyOrder(BuyOrder buyOrder);
    }
}
