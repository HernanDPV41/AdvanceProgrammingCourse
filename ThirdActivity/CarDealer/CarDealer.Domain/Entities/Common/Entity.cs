using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Domain.Entities.Common
{
    /// <summary>
    /// Clase base para todas las entidades en el soporte de datos.
    /// </summary>
    public abstract class Entity
    {
        #region Properties
        
        /// <summary>
        /// Identificador en el soporte de datos.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #endregion

    }
}
