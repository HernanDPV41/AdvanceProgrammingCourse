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
    public abstract class Client
    {
        /// <summary>
        /// Identificador del cliente en el soporte de datos. 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Client() { }
    }
}
