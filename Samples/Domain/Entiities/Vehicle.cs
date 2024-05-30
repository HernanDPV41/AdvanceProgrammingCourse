using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Modela un vehículo.
    /// </summary>
    public abstract class Vehicle
    {
        #region Properties

        public EnergySource EnergySource { get; set; }

        public string Brand { get; set; }


        #endregion

        public Vehicle(string brand)
        {
            Brand = brand;
        }
    }
}
