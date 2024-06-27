using CarDealer.Contracts;
using CarDealer.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

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
            if (!context.Database.CanConnect())
                context.Database.Migrate();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
