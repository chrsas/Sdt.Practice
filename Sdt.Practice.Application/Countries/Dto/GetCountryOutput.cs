using System.Collections.Generic;
using Sdt.Practice.Application.Cities.Dto;

namespace Sdt.Practice.Application.Countries.Dto
{
    public class GetCountryOutput
    {
        public int Id { get; set; }

        public string EnglishName { get; set; }

        public string ChineseName { get; set; }

        public IEnumerable<GetCityOutput> Cities { get; set; }
    }
}