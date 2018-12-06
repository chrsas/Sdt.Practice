using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sdt.Practice.Application.Cities.Dto;
using Sdt.Practice.Application.Countries.Dto;
using Sdt.Practice.Domain.Cities;
using Sdt.Practice.Domain.Countries;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Application.Cities
{
    internal class CityService : ICityService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IMapper _mapper;
        private readonly ICountryManager _countryManager;

        public CityService(IRepository<Country> countryRepository,
            IMapper mapper,
            ICountryManager countryManager)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _countryManager = countryManager;
        }

        public IEnumerable<GetCityOutput> GetCities(int countryId)
        {
            return _countryRepository.GetAll().Where(c => c.Id == countryId)
                .Include(c => c.Cities)
                .SelectMany(c => c.Cities.Select(city => new GetCityOutput
                {
                    Id = city.Id,
                    Name = city.Name,
                    Code = city.Code
                }));
        }

        public void InsertCities(int countryId, ICollection<InsertCityInput> inputs)
        {
            var cities = _mapper.Map<ICollection<City>>(inputs);
            var country = _countryRepository.FirstOrDefault(c => c.Id == countryId);
            if (country == null)
                throw new ValidationException("");
            _countryManager.InsertCities(country, cities);
        }
    }
}
