using Microsoft.Extensions.DependencyInjection;
using Sdt.Practice.Data.EfCore.Repositories;
using Sdt.Practice.Domain.Models;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Data
{
    public static class DataModule
    {
        public static void Register(IServiceCollection service)
        {
            service.AddTransient<IRepository<Country>, Repository<Country>>();
        }
    }
}