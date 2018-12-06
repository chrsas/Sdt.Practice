using Microsoft.Extensions.DependencyInjection;
using Sdt.Practice.Application.Cities;
using Sdt.Practice.Application.Countries;
using Sdt.Practice.Domain;

namespace Sdt.Practice.Application
{
    public static class ApplicationModule
    {
        public static void Register(IServiceCollection service)
        {
            service.AddTransient<ICountryService, CountryService>();
            service.AddTransient<ICityService, CityService>();

            DomainModule.Register(service);
        }
    }
}