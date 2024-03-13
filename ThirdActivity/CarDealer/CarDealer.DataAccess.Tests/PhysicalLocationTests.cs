using CarDealer.DataAccess.Abstract.Clients;
using CarDealer.DataAccess.Repositories;
using CarDealer.DataAccess.Tests.Utilities;
using CarDealer.Domain.Entities.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Tests
{
    [TestClass]
    public class PhysicalLocationTests
    {

        private IPhysicalLocationRepository _physicalLocationRepository;

        public PhysicalLocationTests()
        {
            _physicalLocationRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }


        [DataRow("Cuba", "Habana", "M e/ 17 y 19 Vedado")]
        [DataRow("España", "Barcelona", "15 e/ 20 y 21 Miraflores")]
        [DataRow("Cuba", "Habana", "42 e/ 3ra y 5ta Playa")]
        [TestMethod]
        public void Can_Create_Physical_Location(string country, string city, string address)
        {
            // Arrange
            _physicalLocationRepository.BeginTransaction();

            // Execute
            var newLocation = _physicalLocationRepository.Create(country, city, address);
            _physicalLocationRepository.PartialCommit();
            var loadedLocation = _physicalLocationRepository.Get(newLocation.Id);
            _physicalLocationRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedLocation);
            Assert.AreEqual(country, loadedLocation.Country);
            Assert.AreEqual(city, loadedLocation.City);
            Assert.AreEqual(address, loadedLocation.Address);
        }

        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Physical_Location_By_Id(int id)
        {
            // Arrange
            _physicalLocationRepository.BeginTransaction();

            // Execute
            var location = _physicalLocationRepository.Get(id);
            _physicalLocationRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(location);
        }

        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_Physical_Location(int id)
        {
            // Arrange
            _physicalLocationRepository.BeginTransaction();

            // Execute
            var oldLocation = _physicalLocationRepository.Get(id);
            Assert.IsNotNull(oldLocation);
            _physicalLocationRepository.Delete(oldLocation);
            _physicalLocationRepository.PartialCommit();
            var loadedLocation = _physicalLocationRepository.Get(id);
            _physicalLocationRepository.CommitTransaction();

            // Assert
            Assert.IsNull(loadedLocation);
        }

    }
}
