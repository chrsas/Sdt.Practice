using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using AutoMapper;
using Sdt.Practice.Application.Cities.Dto;
using Sdt.Practice.Application.Countries.Dto;
using Sdt.Practice.Application.Extentions;
using Sdt.Practice.Domain.Cities;
using Sdt.Practice.Domain.Countries;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Application.Countries
{
    internal class CountryService : ICountryService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly ICountryManager _countryManager;
        private readonly IRepository<City> _cityRepository;
        private readonly IMapper _mapper;

        public CountryService(IRepository<Country> countryRepository,
            ICountryManager countryManager,
            IRepository<City> cityRepository,
            IMapper mapper)
        {
            _countryRepository = countryRepository;
            _countryManager = countryManager;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public PagedResponse<GetCountryOutput> GetCountries(GetCountryInput input, PageRequest pageRequest)
        {
            var query = _countryRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.EnglishName), c => c.EnglishName.Contains(input.EnglishName))
                .WhereIf(!string.IsNullOrWhiteSpace(input.ChineseName), c => c.ChineseName.Contains(input.ChineseName));
            var amount = query.Count();
            query = query.Skip(pageRequest.PageIndex * pageRequest.ItemCount).Take(pageRequest.ItemCount);
            return new PagedResponse<GetCountryOutput>()
            {
                PageIndex = pageRequest.PageIndex,
                TotalAmount = amount,
                ItemCount = pageRequest.ItemCount,
                Payload = _mapper.Map<IEnumerable<GetCountryOutput>>(query.ToList()),
            };
        }

        public GetCountryOutput GetCountry(int id)
        {
            var result = _countryRepository.FirstOrDefault(c => c.Id == id);
            return _mapper.Map<GetCountryOutput>(result);
        }

        public GetCountryOutput GetCountryWithCities(int id)
        {
            return (from country in _countryRepository.GetAll()
                    select new GetCountryOutput
                    {
                        Id = country.Id,
                        EnglishName = country.EnglishName,
                        ChineseName = country.ChineseName,
                        Cities = _cityRepository.GetAll().Where(c => c.CountryId == country.Id)
                            .Select(city => new GetCityOutput
                            {
                                Id = city.Id,
                                Name = city.Name,
                                Code = city.Code
                            }).ToList(),
                    }).FirstOrDefault(c => c.Id == id);

        }

        public void InsertCountry(InsertCountryInput input)
        {
            //var country = _mapper.Map<Country>(input);
            var country = new Country()
            {
                EnglishName = input.EnglishName,
                ChineseName = input.ChineseName,
            };
            _countryManager.Insert(country);
        }

        public void UpdateCountry(UpdateCountryInput input)
        {
            var country = _mapper.Map<Country>(input);
            country.Id = input.Id;
            _countryManager.Update(country);
        }
    }
}
