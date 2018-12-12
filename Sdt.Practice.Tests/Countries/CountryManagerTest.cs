using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NSubstitute;
using Sdt.Practice.Application.Countries;
using Sdt.Practice.Application.Countries.Dto;
using Sdt.Practice.Data.EfCore.Repositories;
using Sdt.Practice.Domain.Countries;
using Sdt.Practice.Domain.Repositories;
using Shouldly;
using Xunit;

namespace Sdt.Practice.Tests.Countries
{
    public class CountryManagerTest
    {
        [Fact]
        public void Insert_Test()
        {
            // Arrange
            var countryRepositoryMock = Substitute.For<IRepository<Country>>();
            countryRepositoryMock.GetAll().Returns(new List<Country>().AsQueryable());
            var manager = new CountryManager(countryRepositoryMock, new NullUnitOfWork());
            var country = new Country()
            {
                EnglishName = "China",
                ChineseName = "中国",
            };
            // Act
            manager.Insert(country);

            // Assert
            countryRepositoryMock.Received().Insert(Arg.Is(country));
        }


        [Fact]
        public void Insert_EnglishNameExists_ThrowException()
        {
            // Arrange
            var countryRepositoryMock = Substitute.For<IRepository<Country>>();
            countryRepositoryMock.GetAll().Returns(new List<Country>()
            {
                new  Country()
                {
                    Id = 1,
                    EnglishName = "China",
                    ChineseName = "中国",
                }
            }.AsQueryable());
            var manager = new CountryManager(countryRepositoryMock, new NullUnitOfWork());
            var country = new Country()
            {
                EnglishName = "China",
                ChineseName = "中国",
            };
            // Act
            var exception = Assert.Throws<ValidationException>(() => { manager.Insert(country); });

            // Assert
            exception.Message.ShouldContain("名称有重复");
        }

        [Theory]
        [InlineData("Test1")]
        [InlineData("Test2")]
        public void Update_Test(string targetName)
        {
            // Arrange
            var countryRepositoryMock = Substitute.For<IRepository<Country>>();
            var dbCountry = new Country()
            {
                Id = 1,
                EnglishName = "China",
                ChineseName = "中国",
            };
            countryRepositoryMock.GetAll().Returns(new List<Country>()
            {
                dbCountry
            }.AsQueryable());
            var manager = new CountryManager(countryRepositoryMock, new NullUnitOfWork());
            var country = new Country()
            {
                Id = 1,
                EnglishName = "China",
                ChineseName = targetName,
            };
            // Act
            manager.Update(country);

            // Assert
            dbCountry.ChineseName.ShouldBe(targetName);
        }
    }
}