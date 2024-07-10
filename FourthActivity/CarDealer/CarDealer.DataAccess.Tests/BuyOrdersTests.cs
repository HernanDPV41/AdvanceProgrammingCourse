using CarDealer.Contracts;
using CarDealer.Contracts.Clients;
using CarDealer.Contracts.Orders;
using CarDealer.Contracts.Vehicles;
using CarDealer.DataAccess.Contexts;
using CarDealer.DataAccess.Repositories.Clients;
using CarDealer.DataAccess.Repositories.Orders;
using CarDealer.DataAccess.Repositories.Vehicles;
using CarDealer.DataAccess.Tests.Utilities;
using CarDealer.Domain.Entities.Clients;
using CarDealer.Domain.Entities.Orders;
using CarDealer.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Tests
{
    [TestClass]
    public class BuyOrdersTests
    {

        private IBuyOrderRepository _buyOrderRepository;
        private IClientRepository _clientRepository;
        private IVehicleRepository _vehicleRepository;
        private IUnitOfWork _unitOfWork;

        public BuyOrdersTests()
        {
            ApplicationContext context =
               new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _buyOrderRepository = new BuyOrderRepository(context);
            _clientRepository = new ClientRepository(context);
            _vehicleRepository = new VehicleRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow(0,0,15)]
        [DataRow(0,1,3)]
        [TestMethod]
        public void Can_Add_New_Buy_Order(
          int clientPosition,
          int vehiclePosition,
          int units)
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var client = _clientRepository.GetAllClients<Client>().ElementAt(clientPosition);
            var vehicle = _vehicleRepository.GetAllVehicles<Vehicle>().ElementAt(vehiclePosition);
            BuyOrder buyOrder = new BuyOrder(
                id,
                client,
                vehicle,
                units);

            // Execute
            _buyOrderRepository.AddBuyOrder(buyOrder);
            _unitOfWork.SaveChanges();

            // Assert
            BuyOrder? loadedOrder = _buyOrderRepository.GetBuyOrderById(id);
            Assert.IsNotNull(loadedOrder);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Buy_Order_By_Id(int position)
        {
            // Arrange
            var orders = _buyOrderRepository.GetAllBuyOrders().ToList();
            Assert.IsNotNull(orders);
            Assert.IsTrue(position < orders.Count);
            BuyOrder orderToGet = orders[position];

            // Execute
            BuyOrder? loadedOrder = _buyOrderRepository.GetBuyOrderById(orderToGet.Id);

            // Assert
            Assert.IsNotNull(loadedOrder);
        }

        [TestMethod]
        public void Cannot_Get_Buy_Order_By_Invalid_Id()
        {
            // Arrange

            // Execute
            BuyOrder? loadedOrder = _buyOrderRepository.GetBuyOrderById(Guid.Empty);

            // Assert
            Assert.IsNull(loadedOrder);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Update_Buy_Order(int position)
        {
            // Arrange
            var orders = _buyOrderRepository.GetAllBuyOrders().ToList();
            Assert.IsNotNull(orders);
            Assert.IsTrue(position < orders.Count);
            BuyOrder orderToUpdate = orders[position];

            // Execute
            DateTime paymentDay = DateTime.Now;
            orderToUpdate.PaymentDay = paymentDay;
            _buyOrderRepository.UpdateBuyOrder(orderToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            BuyOrder? loadedOrder = _buyOrderRepository.GetBuyOrderById(orderToUpdate.Id);
            Assert.IsNotNull(loadedOrder);
            Assert.AreEqual(loadedOrder.PaymentDay, paymentDay);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Buy_Order(int position)
        {
            // Arrange
            var orders = _buyOrderRepository.GetAllBuyOrders().ToList();
            Assert.IsNotNull(orders);
            Assert.IsTrue(position < orders.Count);
            BuyOrder orderToDelete = orders[position];

            // Execute
            _buyOrderRepository.DeleteBuyOrder(orderToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            BuyOrder? loadedOrder = _buyOrderRepository.GetBuyOrderById(orderToDelete.Id);
            Assert.IsNull(loadedOrder);
        }
    }
}
