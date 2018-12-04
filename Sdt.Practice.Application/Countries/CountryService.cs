using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Sdt.Practice.Application.Dto;
using Sdt.Practice.Application.Extentions;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Application.Countries
{
    class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
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
    }
}
