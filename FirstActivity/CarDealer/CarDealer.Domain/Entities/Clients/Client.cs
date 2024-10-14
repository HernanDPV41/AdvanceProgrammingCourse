using CarDealer.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Domain.Entities.Clients
{
    /// <summary>
    /// Modela un cliente de concesionario de autos.
    /// </summary>
    public abstract class Client : Entity
    {
        /// <summary>
        /// Requerido por EntityFramework.
        /// </summary>
        protected Client()
        {
            
        }

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Client(Guid id) : base(id) { }
    }
}
