using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using AutoMapper;
using Sdt.Practice.Application.Countries.Dto;
using Sdt.Practice.Application.Extentions;
using Sdt.Practice.Domain.Countries;
using Sdt.Practice.Domain.Models;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Application.Countries
{
    class CountryService : ICountryService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly ICountryManager _countryManager;
        private readonly IMapper _mapper;

        public CountryService(IRepository<Country> countryRepository,
            ICountryManager countryManager,
            IMapper mapper)
        {
            _countryRepository = countryRepository;
            _countryManager = countryManager;
            _mapper = mapper;
        }

        public IEnumerable<GetCountryOutput> GetCountries(GetCountryInput input, PageRequest pageRequest)
        {
            var query = _countryRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.EnglishName), c => c.EnglishName.Contains(input.EnglishName))
                .WhereIf(!string.IsNullOrWhiteSpace(input.ChineseName), c => c.ChineseName.Contains(input.ChineseName));
            query = query.Skip(pageRequest.PageIndex * pageRequest.PageCount).Take(pageRequest.PageCount);
            return _mapper.Map<IEnumerable<GetCountryOutput>>(query.ToList());
        }

        public GetCountryOutput GetCountry(int id)
        {
            var result = _countryRepository.FirstOrDefault(c => c.Id == id);
            return _mapper.Map<GetCountryOutput>(result);
        }

        public void InsertCountry(InsertCountryInput input)
        {
            var country = _mapper.Map<Country>(input);
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
