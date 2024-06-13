using CarDealer.Contracts;
using CarDealer.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess
{
    /// <summary>
    /// Implementación de <see cref="IUnitOfWork"/>.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public Task SaveChangesAsync(CancellationToken token)
        {
            return _context.SaveChangesAsync(token);
        }
    }
}
