using CarDealer.DataAccess.Abstract.Common;
using CarDealer.Domain.Entities.Common;
using CarDealer.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Repositories
{
    public partial class ApplicationRepository : IPriceRepository
    {
        public Price Create(MoneyType currency, double value)
        {
            Price price = new Price(currency, value);
            _context.Add(price);
            return price;
        }

        public void Delete(Price price)
        {
            _context.Remove(price);
        }

        public void Update(Price price)
        {
            _context.Update(price);
        }

        Price? IPriceRepository.Get(int id)
        {
            return _context.Set<Price>().Find(id);
        }
    }
}
