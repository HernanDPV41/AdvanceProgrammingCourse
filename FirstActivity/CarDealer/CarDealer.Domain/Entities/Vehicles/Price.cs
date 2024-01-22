using CarDealer.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Domain.Entities.Vehicles
{
    /// <summary>
    /// Precio de una entidad del consecionario.
    /// </summary>
    public class Price
    {
        #region Properties

        /// <summary>
        /// Divisa a en la que se expresa el valor del automóvil.
        /// </summary>
        public MoneyType Currency { get; }

        /// <summary>
        /// Valor del precio.
        /// </summary>
        public double Value { get; set; }

        #endregion

        /// <summary>
        /// Inicializa un objeto <see cref="Price"/>
        /// </summary>
        /// <param name="type">Divisa a en la que se expresa el valor del automóvil.</param>
        /// <param name="value">Valor del precio.</param>
        public Price(MoneyType currency, double value)
        {
            Currency = currency;
            Value = value;
        }
    }
}
