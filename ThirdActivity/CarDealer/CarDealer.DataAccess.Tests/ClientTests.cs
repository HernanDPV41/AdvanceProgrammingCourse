using CarDealer.Contracts;
using CarDealer.Contracts.Clients;
using CarDealer.Contracts.Vehicles;
using CarDealer.DataAccess.Contexts;
using CarDealer.DataAccess.Repositories.Clients;
using CarDealer.DataAccess.Repositories.Vehicles;
using CarDealer.DataAccess.Tests.Utilities;
using CarDealer.Domain.Abstract;
using CarDealer.Domain.Entities.Clients;
using CarDealer.Domain.Entities.Vehicles;
using CarDealer.Domain.Types;
using CarDealer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarDealer.DataAccess.Tests
{
    [TestClass]
    public class ClientTests
    {

        private IClientRepository _clientRepository;

        private IUnitOfWork _unitOfWork;

        public ClientTests()
        {
            ApplicationContext context =
               new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _clientRepository = new ClientRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("78745845465","Pedro Pablo Gómez",28)]
        [DataRow("78254845465","Javier Valdés Gonzalez",35)]
        [TestMethod]
        public void Can_Add_New_Private_Client(
            string idNumber,
            string name,
            int age) 
        {
            // Arrange
            Guid id = Guid.NewGuid();
            PrivateClient privateClient = new PrivateClient(
                id,
                idNumber,
                name,
                age);

            // Execute
            _clientRepository.AddClient(privateClient);
            _unitOfWork.SaveChanges();

            // Assert
            PrivateClient? loadedClient = _clientRepository.GetClientById<PrivateClient>(id);
            Assert.IsNotNull(loadedClient);
        }

        [DataRow("Etecsa", "Cuba", "Habana", "Obispo y Aguiar")]
        [DataRow("Microsoft", "USA", "California", "Palo Alto, Silicon Valley")]
        [TestMethod]
        public void Can_Add_New_Enterprise_Client(
            string brand,
            string country,
            string city,
            string address)
        {
            // Arrange
            Guid id = Guid.NewGuid();
            EnterpriseClient enterpriseClient = new EnterpriseClient(
                id,
                brand,
                new PhysicalLocation(
                    country,
                    city,
                    address));

            // Execute
            _clientRepository.AddClient(enterpriseClient);
            _unitOfWork.SaveChanges();

            // Assert
            EnterpriseClient? loadedClient = _clientRepository.GetClientById<EnterpriseClient>(id);
            Assert.IsNotNull(loadedClient);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Private_Client_By_Id(int position)
        {
            // Arrange
            var clients = _clientRepository.GetAllClients<PrivateClient>().ToList();
            Assert.IsNotNull(clients);
            Assert.IsTrue(position < clients.Count);
            Client clientToGet = clients[position];

            // Execute
            PrivateClient? loadedClient = _clientRepository.GetClientById<PrivateClient>(clientToGet.Id);

            // Assert
            Assert.IsNotNull(loadedClient);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Enterprise_Client_By_Id(int position)
        {
            // Arrange
            var clients = _clientRepository.GetAllClients<EnterpriseClient>().ToList();
            Assert.IsNotNull(clients);
            Assert.IsTrue(position < clients.Count);
            EnterpriseClient clientToGet = clients[position];

            // Execute
            EnterpriseClient? loadedClient = _clientRepository.GetClientById<EnterpriseClient>(clientToGet.Id);

            // Assert
            Assert.IsNotNull(loadedClient);
        }

        [TestMethod]
        public void Cannot_Get_Private_Client_By_Invalid_Id()
        {
            // Arrange

            // Execute
            PrivateClient? loadedClient = _clientRepository.GetClientById<PrivateClient>(Guid.Empty);

            // Assert
            Assert.IsNull(loadedClient);
        }

        [TestMethod]
        public void Cannot_Get_Enterprise_Client_By_Invalid_Id()
        {
            // Arrange

            // Execute
            EnterpriseClient? loadedClient = _clientRepository.GetClientById<EnterpriseClient>(Guid.Empty);

            // Assert
            Assert.IsNull(loadedClient);
        }

        [DataRow(0, 45)]
        [TestMethod]
        public void Can_Update_Private_Client(int position, int age)
        {
            // Arrange
            var clients = _clientRepository.GetAllClients<PrivateClient>().ToList();
            Assert.IsNotNull(clients);
            Assert.IsTrue(position < clients.Count);
            PrivateClient clientToUpdate = clients[position];

            // Execute
            clientToUpdate.Age = age;
            _clientRepository.UpdateClient(clientToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            PrivateClient? loadedClient = _clientRepository.GetClientById<PrivateClient>(clientToUpdate.Id);
            Assert.IsNotNull(loadedClient);
            Assert.AreEqual(loadedClient.Age, age);
        }

        [DataRow(0, "España", "Madrid", "Ordoñez y San Sebastián")]
        [TestMethod]
        public void Can_Update_Enterprise_Client(int position, string country, string city, string address)
        {
            // Arrange
            var clients = _clientRepository.GetAllClients<EnterpriseClient>().ToList();
            Assert.IsNotNull(clients);
            Assert.IsTrue(position < clients.Count);
            EnterpriseClient clientToUpdate = clients[position];

            // Execute
            clientToUpdate.Location = new PhysicalLocation(country,city,address);
            _clientRepository.UpdateClient(clientToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            EnterpriseClient? loadedClient = _clientRepository.GetClientById<EnterpriseClient>(clientToUpdate.Id);
            Assert.IsNotNull(loadedClient);
            Assert.AreEqual(loadedClient.Location, new PhysicalLocation(country,city,address));
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Private_Client(int position)
        {
            // Arrange
            var clients = _clientRepository.GetAllClients<PrivateClient>().ToList();
            Assert.IsNotNull(clients);
            Assert.IsTrue(position < clients.Count);
            PrivateClient clientToDelete = clients[position];

            // Execute
            _clientRepository.DeleteClient(clientToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            PrivateClient? loadedClient = _clientRepository.GetClientById<PrivateClient>(clientToDelete.Id);
            Assert.IsNull(loadedClient);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Enterprise_Client(int position)
        {
            // Arrange
            var clients = _clientRepository.GetAllClients<EnterpriseClient>().ToList();
            Assert.IsNotNull(clients);
            Assert.IsTrue(position < clients.Count);
            EnterpriseClient clientToDelete = clients[position];

            // Execute
            _clientRepository.DeleteClient(clientToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            EnterpriseClient? loadedClient = _clientRepository.GetClientById<EnterpriseClient>(clientToDelete.Id);
            Assert.IsNull(loadedClient);
        }
    }
}
