using System.Collections.Generic;
using Sdt.Practice.Application.Countries.Dto;

namespace Sdt.Practice.Application.Countries
{
    public interface ICountryService
    {
        PagedResponse<GetCountryOutput> GetCountries(GetCountryInput input, PageRequest pageRequest);

        GetCountryOutput GetCountry(int id);

        void InsertCountry(InsertCountryInput input);

        void UpdateCountry(UpdateCountryInput input);
        GetCountryOutput GetCountryWithCities(int id);
    }
}