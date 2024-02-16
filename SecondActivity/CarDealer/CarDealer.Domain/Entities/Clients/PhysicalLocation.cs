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
    /// Modela la ubicación geográfica de una entidad.
    /// </summary>
    public class PhysicalLocation
    {

        #region Properties
        /// <summary>
        /// Identificador en el soporte de datos.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhysicalLocationId { get; set; }
        /// <summary>
        /// País.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Ciudad.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Dirección local.
        /// </summary>
        public string Address { get; }

        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected PhysicalLocation() { }

        /// <summary>
        /// Inicializa un objeto <see cref="PhysicalLocation"/>.
        /// </summary>
        /// <param name="country">País.</param>
        /// <param name="city">Ciudad.</param>
        /// <param name="address">Dirección.</param>
        public PhysicalLocation(string country, string city, string address)
        {
            Country = country;
            City = city;
            Address = address;
        }

        public override string ToString()
        {
            return $"{Country},{City},{Address}";
        }

    }
}
