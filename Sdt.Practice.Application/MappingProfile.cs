using AutoMapper;
using Sdt.Practice.Application.Cities.Dto;
using Sdt.Practice.Application.Countries.Dto;
using Sdt.Practice.Domain.Cities;
using Sdt.Practice.Domain.Countries;

namespace Sdt.Practice.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InsertCountryInput, Country>(MemberList.Source);
            CreateMap<InsertCityInput, City>(MemberList.Source);
        }
    }
}