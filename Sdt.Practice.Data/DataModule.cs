using Microsoft.Extensions.DependencyInjection;
using Sdt.Practice.Data.EfCore.Repositories;
using Sdt.Practice.Domain.Cities;
using Sdt.Practice.Domain.Countries;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Data
{
    public static class DataModule
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddTransient<IRepository<Country>, Repository<Country>>();
            service.AddTransient<IRepository<City>, Repository<City>>();
        }
    }
}