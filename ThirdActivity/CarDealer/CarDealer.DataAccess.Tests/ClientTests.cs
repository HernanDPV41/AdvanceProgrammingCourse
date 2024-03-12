using CarDealer.DataAccess.Abstract.Clients;
using CarDealer.DataAccess.Repositories;
using CarDealer.DataAccess.Tests.Utilities;
using CarDealer.Domain.Entities.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Tests
{
    [TestClass]
    public class ClientTests
    {

        private IClientRepository _clientRepository;


        public ClientTests()
        {
            _clientRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [TestMethod]
        [DataRow("02154215","Pedro",24)]
        [DataRow("02158115","Juan",48)]
        [DataRow("95895915","Jose",32)]
        public void Can_Create_PrivateClient(string idNumber, string name, int age)
        {
            // Arrange
            _clientRepository.BeginTransaction();

            // Execute
            var newClient = _clientRepository.CreatePrivateClient(idNumber, name, age);
            _clientRepository.PartialCommit();
            var loadedClient = _clientRepository.GetClient<PrivateClient>(newClient.Id);
            _clientRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedClient);
            Assert.AreEqual(loadedClient.Name, newClient.Name);
            Assert.AreEqual(loadedClient.IDNumber, newClient.IDNumber);
            Assert.AreEqual(loadedClient.Age, newClient.Age);
        }

    }
}
