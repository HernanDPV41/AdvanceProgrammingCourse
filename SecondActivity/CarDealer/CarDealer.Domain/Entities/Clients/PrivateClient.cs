using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Domain.Entities.Clients
{
    /// <summary>
    /// Modela una persona natural cliente del concesionario.
    /// </summary>
    public class PrivateClient : Client
    {
        #region Properties

        /// <summary>
        /// Nombre y apellidos de la persona.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Edad de la persona.
        /// </summary>
        public int Age { get;}

        /// <summary>
        /// Identificador de la persona.
        /// </summary>
        public string ID { get; }

        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected PrivateClient() { }

        /// <summary>
        /// Inicializa un objeto <see cref="PrivateClient"/>.
        /// </summary>
        /// <param name="id">Identificador del cliente.</param>
        /// <param name="name">Nombre del cliente.</param>
        /// <param name="age">Edad del cliente.</param>
        public PrivateClient(string id, string name = "", int age = -1)
        {
            Name = name;
            Age = age;
            ID = id;
        }

    }
}
