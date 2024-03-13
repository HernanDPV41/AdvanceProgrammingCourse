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
        [DataRow("02154215", "Pedro", 24)]
        [DataRow("02158115", "Juan", 48)]
        [DataRow("95895915", "Jose",-1)]
        public void Can_Create_PrivateClient(string idNumber, string name, int age)
        {
            // Arrange
            _clientRepository.BeginTransaction();
            PrivateClient? newClient;
            // Execute
           
            if (age!=-1)
            newClient = _clientRepository.CreatePrivateClient(idNumber, name, age);
            else
            newClient = _clientRepository.CreatePrivateClient(idNumber, name);

            _clientRepository.PartialCommit();
            var loadedClient = _clientRepository.GetClient<PrivateClient>(newClient.Id);
            _clientRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedClient);
            Assert.AreEqual(loadedClient.Name, newClient.Name);
            Assert.AreEqual(loadedClient.IDNumber, newClient.IDNumber);
            Assert.AreEqual(loadedClient.Age, newClient.Age);
        }

        [TestMethod]
        //[DataRow("Toyota", "Pedro", 24)]
        //[DataRow("Porsche", "Juan", 48)]
        //[DataRow("Honda", "Jose", 32)]
        [DataRow("Louis Vutton", 1)]
        [DataRow("Copextel", 3)]
        [DataRow("Bravo", 2)]
        public void Can_Create_EnterpriseClient(string brand,int physicalLocationId )
        {
            // Arrange
            _clientRepository.BeginTransaction();
            var physicalLocation= ((IPhysicalLocationRepository)_clientRepository).Get(physicalLocationId);
            if (physicalLocation is null)
                Assert.Fail();

            // Execute
            var newClient = _clientRepository.CreateEnterpriseClient(brand, physicalLocation);
            _clientRepository.PartialCommit();
            var loadedClient = _clientRepository.GetClient<EnterpriseClient>(newClient.Id);
            _clientRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedClient);
            Assert.AreEqual(loadedClient.Brand, newClient.Brand);
            Assert.AreEqual(loadedClient.LocationId, physicalLocationId); 
        }

        [DataRow(6)]
        [TestMethod]
        public void Can_Get_Clients(int count)
        {
            //Arrange
            _clientRepository.BeginTransaction();

            //Execute
            var clients = _clientRepository.GetAll();
            _clientRepository.CommitTransaction();

            // Assert
            Assert.AreEqual(count,clients.Count());
        }

        [DataRow(26, 1)]
        [DataRow(19,0)]
        [DataRow(29,2)]
        [TestMethod]
        public void Can_Update_PrivateClient(int age, int pos)
        {
            //Arrange
            _clientRepository.BeginTransaction();
            var clients = _clientRepository.GetAll().OfType<PrivateClient>().ToList();
            Assert.IsNotNull(clients);
            var client =clients.ElementAt(pos);
            Assert.IsNotNull(client);

            //Execute
            client.Age = age;
            _clientRepository.Update(client);
            _clientRepository.PartialCommit();

            //Assert
            var updatedClient=_clientRepository.GetClient<PrivateClient>(client.Id);
            Assert.IsNotNull(updatedClient);
            Assert.AreEqual(updatedClient.Age, age);

        }

        [DataRow("Autoviajes", 0)]
        [DataRow("SpaceX",2)] 
        [TestMethod]
        public void Can_Update_EnterpriseClient(string brand, int pos)
        {
            //Arrange
            _clientRepository.BeginTransaction();
            var clients = _clientRepository.GetAll().OfType<EnterpriseClient>().ToList();
            Assert.IsNotNull(clients);
            var client =clients.ElementAt(pos);
            Assert.IsNotNull(client);

            //Execute
            client.Brand = brand;
            _clientRepository.Update(client);
            _clientRepository.PartialCommit();

            //Assert
            var updatedClient=_clientRepository.GetClient<EnterpriseClient>(client.Id);
            _clientRepository.CommitTransaction();
            Assert.IsNotNull(updatedClient);
            Assert.AreEqual(updatedClient.Brand, brand);

        }

        [DataRow(5)]
        [DataRow(2)] 
        [DataRow(0)] 
        [TestMethod]
        public void Can_Update_DeleteClient(int pos)
        {
            //Arrange
            _clientRepository.BeginTransaction();
            var clients = _clientRepository.GetAll();
            Assert.IsNotNull(clients);
            var count=clients.Count();
            var client =clients.ElementAt(pos);
            Assert.IsNotNull(client);

            //Execute 
            _clientRepository.Delete(client);
            _clientRepository.PartialCommit();

            //Assert
            clients = _clientRepository.GetAll();
            Assert.AreEqual(count-1, clients.Count());
            var deletedClient=_clientRepository.GetClient<Client>(client.Id);
            _clientRepository.CommitTransaction();
            Assert.IsNull(deletedClient);

        }
    }
}
