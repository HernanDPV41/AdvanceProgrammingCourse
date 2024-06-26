using CarDealer.Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Contracts.Clients
{
    /// <summary>
    /// Describe las funcionalidades necesarias
    /// para dar persistencia a clientes.
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Añade un cliente al soporte de datos.
        /// </summary>
        /// <param name="client">Cliente a añadir.</param>
        void AddClient(Client client);

        /// <summary>
        /// Obtiene un cliente del soporte de datos a partir de su identificador.
        /// </summary>
        /// <typeparam name="T">Tipo de cliente a obtener</typeparam>
        /// <param name="id">Identificador del cliente.</param>
        /// <returns>Cliente obtenido del soporte de datos; de no existir, <see langword="null"/>.</returns>
        T? GetClientById<T>(Guid id) where T : Client;

        /// <summary>
        /// Actualiza el valor de un cliente en el soporte de datos.
        /// </summary>
        /// <param name="client">Instancia con la información a actualizar del cliente.</param>
        void UpdateClient(Client client);

        /// <summary>
        /// Elimina un cliente del soporte de datos
        /// </summary>
        /// <param name="client">Cliente a eliminar.</param>
        void DeleteClient(Client client);
    }
}
