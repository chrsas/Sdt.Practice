using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sdt.Practice.Domain.Cities;

namespace Sdt.Practice.Domain.Countries
{
    public class Country
    {
        public Country()
        {
            Cities = new List<City>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string EnglishName { get; set; }

        [MaxLength(100)]
        public string ChineseName { get; set; }

        public List<City> Cities { get; set; }
    }
}