using System.Collections.Generic;
using Sdt.Practice.Domain.Cities;

namespace Sdt.Practice.Domain.Countries
{
    public interface ICountryManager
    {
        void Insert(Country country);

        void Update(Country country);
        void InsertCities(Country country, ICollection<City> cities);
    }
}