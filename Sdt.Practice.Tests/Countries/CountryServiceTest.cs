using System.Collections.Generic;
using AutoMapper;
using NSubstitute;
using Sdt.Practice.Application.Countries;
using Sdt.Practice.Application.Countries.Dto;
using Sdt.Practice.Domain.Cities;
using Sdt.Practice.Domain.Countries;
using Shouldly;
using Xunit;

namespace Sdt.Practice.Tests.Countries
{
    public class CountryServiceTest
    {
        [Fact]
        public void InsertCountry_Test()
        {
            // Arrange
            var managerMock = Substitute.For<ICountryManager>();
            var service = new CountryService(null, managerMock, null, null);

            // Act
            service.InsertCountry(new InsertCountryInput()
            {
                EnglishName = "China",
                ChineseName = "中国",
            });

            // Assert
            managerMock.Received().Insert(Arg.Is<Country>(c => c.EnglishName == "China" && c.ChineseName == "中国"));
        }
    }
}
