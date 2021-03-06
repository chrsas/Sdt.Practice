﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sdt.Practice.Domain.Cities;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Domain.Countries
{
    internal class CountryManager : ICountryManager
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IUnitOfWork _uow;

        public CountryManager(IRepository<Country> countryRepository, IUnitOfWork uow)
        {
            _countryRepository = countryRepository;
            _uow = uow;
        }

        public void Insert(Country country)
        {
            CheckNameExist(country);
            _countryRepository.Insert(country);
            _uow.SaveChanges();
        }

        public void Update(Country country)
        {
            CheckNameExist(country);
            var dbCountry = _countryRepository.GetAll().FirstOrDefault(c => c.Id == country.Id);
            if (dbCountry == null)
                throw new ValidationException($"没有Id为 {country.Id} 的实体");
            dbCountry.ChineseName = country.ChineseName;
            dbCountry.EnglishName = country.EnglishName;
            _uow.SaveChanges();
        }

        private void CheckNameExist(Country country)
        {
            if (_countryRepository.GetAll()
                .Any(c => c.Id != country.Id && (c.ChineseName == country.ChineseName || c.EnglishName == country.EnglishName)))
                throw new ValidationException("名称有重复");
        }

        public void InsertCities(Country country, ICollection<City> cities)
        {
            country.Cities.AddRange(cities);
            _uow.SaveChanges();
        }
    }
}