using AutoMapper;
using Sdt.Practice.Application.Countries.Dto;
using Sdt.Practice.Domain.Models;

namespace Sdt.Practice.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InsertCountryInput, Country>(MemberList.Source);
        }
    }
}