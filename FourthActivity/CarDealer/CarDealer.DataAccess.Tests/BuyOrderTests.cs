using CarDealer.DataAccess.Abstract.Clients;
using CarDealer.DataAccess.Abstract.Orders;
using CarDealer.DataAccess.Abstract.Vehicles;
using CarDealer.DataAccess.Repositories;
using CarDealer.DataAccess.Tests.Utilities;
using CarDealer.Domain.Entities.Clients;
using CarDealer.Domain.Entities.Common;
using CarDealer.Domain.Entities.Types;
using CarDealer.Domain.Entities.Vehicles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Tests
{
    [TestClass]
    public class BuyOrderTests
    {

        private IBuyOrderRepository _repo;


        public BuyOrderTests()
        {
            _repo = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow(0,0,2)]
        [DataRow(1,3,5)]
        [DataRow(3,1,1)]
        [DataRow(2,2,7)]
        [TestMethod]
        public void Can_Create_BuyOrder(int clientPos, int vehiclePos, int units)
        {
            //Arrange
            _repo.BeginTransaction();
            var client=((IClientRepository)_repo).GetAll().ElementAtOrDefault(clientPos);
            Assert.IsNotNull(client);
            var vehicle=((IVehicleRepository)_repo).GetAllVehicles().ElementAtOrDefault(vehiclePos);
            Assert.IsNotNull(vehicle);

            //Execute
            var buyOrder=_repo.Create(client, vehicle, units);
            _repo.PartialCommit();
            var loadedOrder=_repo.Get(buyOrder.Id);
            _repo.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedOrder);
            Assert.AreEqual(buyOrder.VehicleId, loadedOrder.VehicleId);
            Assert.AreEqual(buyOrder.ClientId, loadedOrder.ClientId);
            Assert.AreEqual(buyOrder.Units, loadedOrder.Units);
        }

        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(3, 1)]
        [DataRow(2, 1)]
        [TestMethod]
        public void Can_GetByClient_BuyOrder(int clientPos, int count)
        {
            //Arrange
            _repo.BeginTransaction();
            var client = ((IClientRepository)_repo).GetAll().ElementAtOrDefault(clientPos);
            Assert.IsNotNull(client);

            //Execute
            var buyOrder=_repo.GetByClient(client);

            //Assert
            Assert.AreEqual(buyOrder.Count(), count);
        }

        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(3, 1)]
        [DataRow(2, 1)]
        [TestMethod]
        public void Can_GetByVehicle_BuyOrder(int vehiclePos, int count)
        {
            //Arrange
            _repo.BeginTransaction();
            var vehicle = ((IVehicleRepository)_repo).GetAllVehicles().ElementAtOrDefault(vehiclePos);
            Assert.IsNotNull(vehicle);

            //Execute
            var buyOrder=_repo.GetByVehicle(vehicle);

            //Assert
            Assert.AreEqual(buyOrder.Count(), count);
        }

    }
}
