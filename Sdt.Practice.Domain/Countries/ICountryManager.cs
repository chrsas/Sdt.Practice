using Sdt.Practice.Domain.Models;

namespace Sdt.Practice.Domain.Countries
{
    public interface ICountryManager
    {
        void Insert(Country country);

        void Update(Country country);
    }
}