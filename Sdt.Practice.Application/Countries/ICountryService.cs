using System.Collections.Generic;
using Sdt.Practice.Application.Countries.Dto;

namespace Sdt.Practice.Application.Countries
{
    public interface ICountryService
    {
        IEnumerable<GetCountryOutput> GetCountries(GetCountryInput input, PageRequest pageRequest);

        GetCountryOutput GetCountry(int id);

        void InsertCountry(InsertCountryInput input);
    }
}