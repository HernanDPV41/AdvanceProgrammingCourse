using CarDealer.Domain.Common;

namespace CarDealer.Domain.ValueObjects
{
    /// <summary>
    /// Modela la ubicación geográfica de una entidad.
    /// </summary>
    public class PhysicalLocation : ValueObject
    {

        #region Properties
       
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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country;
            yield return City;
            yield return Address;
        }
    }
}
