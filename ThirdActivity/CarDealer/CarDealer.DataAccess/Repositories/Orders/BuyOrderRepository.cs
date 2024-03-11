using CarDealer.DataAccess.Abstract.Orders;
using CarDealer.Domain.Entities.Clients;
using CarDealer.Domain.Entities.Orders;
using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Repositories
{
    public partial class ApplicationRepository : IBuyOrderRepository
    {
        public BuyOrder Create(Client client, Vehicle vehicle, int units = 1)
        {
            BuyOrder buyOrder = new BuyOrder(client, vehicle, units);
            _context.Add(buyOrder);
            return buyOrder;
        }

        public void Delete(BuyOrder order)
        {
            _context.Remove(order);
        }

        public IEnumerable<BuyOrder> GetByClient(Client client)
        {
            return _context.Set<BuyOrder>().Where(x => x.ClientId == client.Id).ToList();
        }

        public IEnumerable<BuyOrder> GetByVehicle(Vehicle vehicle)
        {
            return _context.Set<BuyOrder>().Where(x => x.VehicleId == vehicle.Id).ToList();
        }

        BuyOrder? IBuyOrderRepository.Get(int id)
        {
            return _context.Set<BuyOrder>().Find(id);
        }
    }
}
