using CarDealer.DataAccess.Abstract.Common;
using CarDealer.DataAccess.Repositories;
using CarDealer.DataAccess.Tests.Utilities;
using CarDealer.Domain.Entities.Common;
using CarDealer.Domain.Entities.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Tests
{
    [TestClass]
    public class PriceTests
    {
        private IPriceRepository _priceRepository;

        public PriceTests()
        {
            _priceRepository = new ApplicationRepository(ConnectionStringProvider.GetConnectionString());
        }

        [DataRow(MoneyType.MN, 50000)]
        [DataRow(MoneyType.Euro, 6000)]
        [TestMethod]
        public void Can_Create_Price(MoneyType moneyType, double value)
        {
            // Arrange
            _priceRepository.BeginTransaction();

            // Execute
            Price newPrice = _priceRepository.Create(moneyType, value);
            _priceRepository.PartialCommit(); // Generando id del nuevo elemento.
            Price? loadedPrice = _priceRepository.Get(newPrice.Id);
            _priceRepository.CommitTransaction();

            //Assert
            Assert.IsNotNull(loadedPrice);
            Assert.AreEqual(loadedPrice.Currency, moneyType);
            Assert.AreEqual(loadedPrice.Value, value);
        }

        [DataRow(1)]
        [DataRow(2)]
        [TestMethod]
        public void Can_Get_Price(int id)
        {
            // Arrange
            _priceRepository.BeginTransaction();

            // Execute
            var loadedPrice = _priceRepository.Get(id);
            _priceRepository.CommitTransaction();

            // Assert
            Assert.IsNotNull(loadedPrice);
        }

        [DataRow(1,MoneyType.USD,6200)]
        [DataRow(2, MoneyType.MLC, 8000)]
        [TestMethod]
        public void Can_Update_Price(int id, MoneyType moneyType, double value)
        {
            // Arrange
            _priceRepository.BeginTransaction();
            var loadedPrice = _priceRepository.Get(id);
            Assert.IsNotNull(loadedPrice);


            // Execute
            loadedPrice.Currency=moneyType;
            loadedPrice.Value=value; 
            _priceRepository.Update(loadedPrice);

            // Assert
            var modifyedPrice = _priceRepository.Get(id);
            _priceRepository.CommitTransaction();
            Assert.AreEqual(modifyedPrice.Currency, moneyType);
            Assert.AreEqual(modifyedPrice.Value, value);
        }

        [DataRow(1)]
        [TestMethod]
        public void Can_Delete_Price(int id)
        {
            // Arrange
            _priceRepository.BeginTransaction();

            // Execute
            var loadedPrice = _priceRepository.Get(id);
            Assert.IsNotNull(loadedPrice);
            _priceRepository.Delete(loadedPrice);
            _priceRepository.PartialCommit();
            loadedPrice = _priceRepository.Get(id);
            _priceRepository.CommitTransaction();

            // Assert
            Assert.IsNull(loadedPrice);
        }

    }
}
