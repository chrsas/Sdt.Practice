using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using AutoMapper;
using Sdt.Practice.Application.Dto;
using Sdt.Practice.Application.Extentions;
using Sdt.Practice.Domain.Models;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Application.Countries
{
    class CountryService : ICountryService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(IRepository<Country> countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
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

        public void InsertCountry(InsertCountyInput input)
        {
            var country = _mapper.Map<Country>(input);
            if (_countryRepository.GetAll()
                .Any(c => c.ChineseName == input.ChineseName || c.EnglishName == input.EnglishName))
                throw new ValidationException("名称有重复");
            _countryRepository.Insert(country);
            _countryRepository.SaveChanges();
        }
    }
}
