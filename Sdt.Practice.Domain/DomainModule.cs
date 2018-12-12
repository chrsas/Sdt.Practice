using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Sdt.Practice.Domain.Countries;

[assembly: InternalsVisibleTo("Sdt.Practice.Tests")]

namespace Sdt.Practice.Domain
{
    public static class DomainModule
    {
        public static void Register(IServiceCollection service)
        {
            service.AddTransient<ICountryManager, CountryManager>();
        }
    }
}