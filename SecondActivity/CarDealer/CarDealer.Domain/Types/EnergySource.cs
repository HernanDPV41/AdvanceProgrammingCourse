using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Domain.Types
{
    /// <summary>
    /// Fuentes de energía utilizada por los vehículos.
    /// </summary>
    public enum EnergySource
    {
        /// <summary>
        /// Gasolina como fuente de energía.
        /// </summary>
        Gasoline,
        /// <summary>
        /// Petróleo como fuente de energía.
        /// </summary>
        Petroleum,
        /// <summary>
        /// Electricidad como fuente de energía.
        /// </summary>
        Electricity
    }
}
