using CarDealer.Contracts.Orders;
using CarDealer.DataAccess.Contexts;
using CarDealer.DataAccess.Repositories.Common;
using CarDealer.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Repositories.Orders
{
    /// <summary>
    /// Implementación del repositorio <see cref="IBuyOrderRepository"/>.
    /// </summary>
    public class BuyOrderRepository
        : RepositoryBase, IBuyOrderRepository
    {
        public BuyOrderRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddBuyOrder(BuyOrder buyOrder)
        {
            _context.BuyOrders.Add(buyOrder);
        }

        public void DeleteBuyOrder(BuyOrder buyOrder)
        {
            _context.BuyOrders.Remove(buyOrder);
        }

        public IEnumerable<BuyOrder> GetAllBuyOrders()
        {
            return _context.BuyOrders.ToList();
        }

        public BuyOrder? GetBuyOrderById(Guid id)
        {
            return _context.BuyOrders.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateBuyOrder(BuyOrder buyOrder)
        {
            _context.BuyOrders.Update(buyOrder);
        }
    }
}
