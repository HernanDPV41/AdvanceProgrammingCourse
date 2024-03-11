using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Domain.Entities.Types
{
    /// <summary>
    /// Tipos de monedas a utilizar en las transacciones de compra de autos.
    /// </summary>
    public enum MoneyType
    {
        /// <summary>
        /// Moneda nacional.
        /// </summary>
        MN,
        /// <summary>
        /// Dolar estadounidense.
        /// </summary>
        USD,
        /// <summary>
        /// Moneda Libremente Convertible nacional.
        /// </summary>
        MLC,
        /// <summary>
        /// Euro. Moneda de la Unión Europea.
        /// </summary>
        Euro
    }
}
