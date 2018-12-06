using System.Collections.Generic;
using Sdt.Practice.Application.Cities.Dto;
using Sdt.Practice.Application.Countries.Dto;

namespace Sdt.Practice.Application.Cities
{
    public interface ICityService
    {
        IEnumerable<GetCityOutput> GetCities(int countryId);
        void InsertCities(int countryId, ICollection<InsertCityInput> inputs);
        GetCityOutput GetCity(int countryId, int cityId);
    }
}