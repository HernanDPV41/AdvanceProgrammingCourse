using CarDealer.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Domain.Entities.Clients
{
    /// <summary>
    /// Modela un cliente empresarial.
    /// </summary>
    public class EnterpriseClient : Client, IBrand
    {
        #region Properties

        public string Brand { get; set; }

        /// <summary>
        /// Ubicación geográfica de la sede de la empresa cliente.
        /// </summary>
        [NotMapped]
        public PhysicalLocation Location { get; set; }
        
        /// <summary>
        /// Identificador de la ubicación geográfica asociada.
        /// </summary>
        public int LocationId { get; protected set;}

        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected EnterpriseClient() { }

        /// <summary>
        /// Inicializa un objeto <see cref="EnterpriseClient"/>.
        /// </summary>
        /// <param name="brand">Marca de la empresa.</param>
        /// <param name="location">Ubicación geográfica de la empresa.</param>
        public EnterpriseClient(string brand, PhysicalLocation location)
        {
            Brand = brand;
            Location = location;
            LocationId = location.Id;
        }

    }
}
