using System.ComponentModel.DataAnnotations;
using System.Linq;
using Sdt.Practice.Domain.Models;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Domain.Countries
{
    internal class CountryManager : ICountryManager
    {
        private readonly IRepository<Country> _countryRepository;

        public CountryManager(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public void Insert(Country country)
        {
            if (_countryRepository.GetAll()
                .Any(c => c.ChineseName == country.ChineseName || c.EnglishName == country.EnglishName))
                throw new ValidationException("名称有重复");
            _countryRepository.Insert(country);
            _countryRepository.SaveChanges();
        }
    }
}