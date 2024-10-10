using CarDealer.Domain.Types;
using CarDealer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Domain.Utilities.Converters
{
    /// <summary>
    /// Herramienta para convertir precios de un tipo de moneda a otro.
    /// </summary>
    public class PriceConverter
    {
        /// <summary>
        /// Valor actual de la moneda nacional(CUP).
        /// </summary>
        private const double MN_CURRENT_VALUE = 1;

        /// <summary>
        /// Valor actual del USD.
        /// </summary>
        private const double USD_CURRENT_VALUE = 120;

        /// <summary>
        /// Valor actual del Euro.
        /// </summary>
        private const double EURO_CURRENT_VALUE = 120;

        /// <summary>
        /// Valor actual del MLC.
        /// </summary>
        private const double MLC_CURRENT_VALUE = 120;

        /// <summary>
        /// Convierte un precio de una moneda a otra.
        /// </summary>
        /// <param name="currencyTarget">Moneda a la que se quiere convertir.</param>
        /// <param name="price">Precio a convertir.</param>
        /// <returns>Nuevo precio convertido.</returns>
        public Price ConvertTo(MoneyType currencyTarget, Price price)
        {
            // Obteniendo el valor actual de la moneda a la que se quiere convertir.
            double currentCurrencyTargetValue = GetCurrencyCurrentValue(currencyTarget);
            // Obteniendo el valor actual de la moneda de la que se quiere convertir.
            double oldCurrencyValue = GetCurrencyCurrentValue(price.Currency);

            return new Price(currencyTarget, price.Value * (oldCurrencyValue / currentCurrencyTargetValue));
        }

        #region Helpers

        /// <summary>
        /// Obtiene el valor actual de cada tipo de moneda.
        /// </summary>
        /// <param name="type">Tipo de moneda.</param>
        /// <returns>Valor actual de la moneda.</returns>
        private double GetCurrencyCurrentValue(MoneyType type)
        {
            return type switch
            {
                MoneyType.MN => MN_CURRENT_VALUE,
                MoneyType.USD => USD_CURRENT_VALUE,
                MoneyType.MLC => MLC_CURRENT_VALUE,
                MoneyType.Euro => EURO_CURRENT_VALUE,
                _ => throw new NotImplementedException(),
            };
        }

        #endregion

    }
}
