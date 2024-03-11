using CarDealer.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DataAccess.Abstract.Clients
{
    /// <summary>
    /// Define las operaciones a realizar en BD para un cliente.
    /// </summary>
    public interface IClientRepository : IRepository
    {
        /// <summary>
        /// Crea un cliente privado en BD.
        /// </summary>
        /// <param name="idNumber">Identificador del cliente.</param>
        /// <param name="name">Nombre del cliente.</param>
        /// <param name="age">Edad del cliente.</param>
        /// <returns></returns>
        PrivateClient CreatePrivateClient(string idNumber, string name = "", int age = -1);

        /// <summary>
        /// Crea una empresa cliente en BD.
        /// </summary>
        /// <param name="brand">Marca de la empresa.</param>
        /// <param name="location">Ubicación de la empresa.</param>
        /// <returns></returns>
        EnterpriseClient CreateEnterpriseClient(string brand, PhysicalLocation location);
        
        /// <summary>
        /// Obtiene un cliente de BD.
        /// </summary>
        /// <typeparam name="T">Tipo de cliente a obtener.</typeparam>
        /// <param name="id">Identificador del cliente.</param>
        /// <returns>Cliente solicitado de existir en BD, de lo contrario <see langword="null"/> </returns>
        T? Get<T>(int id) where T : Client;

        /// <summary>
        /// Obtiene todos los clientes de BD.
        /// </summary>
        /// <returns>Clientes en BD.</returns>
        IEnumerable<Client> GetAll();

        /// <summary>
        /// Actualiza un cliente en BD.
        /// </summary>
        /// <param name="client">Cliente a actualizar.</param>
        void Update(Client client);

        /// <summary>
        /// Elimina un cliente de BD.
        /// </summary>
        /// <param name="id">Identificador del cliente a eliminar.</param>
        void Delete(int id);

    }
}
