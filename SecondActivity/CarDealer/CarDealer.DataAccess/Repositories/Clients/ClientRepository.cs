using CarDealer.Contracts.Clients;
using CarDealer.DataAccess.Contexts;
using CarDealer.DataAccess.Repositories.Common;
using CarDealer.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Repositories.Clients
{
    /// <summary>
    /// Implementación del repositorio <see cref="IClientRepository"/>.
    /// </summary>
    public class ClientRepository
        : RepositoryBase, IClientRepository
    {
        public ClientRepository(ApplicationContext context)
            : base(context) { }

        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
        }

        public void DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
        }

        public T? GetClientById<T>(Guid id) where T : Client
        {
            return _context.Set<T>().FirstOrDefault(i => i.Id == id);
        }

        public void UpdateClient(Client client)
        {
            _context.Clients.Update(client);
        }
    }
}
