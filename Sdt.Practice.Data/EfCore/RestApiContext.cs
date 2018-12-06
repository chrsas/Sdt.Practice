using Microsoft.EntityFrameworkCore;
using Sdt.Practice.Domain.Cities;
using Sdt.Practice.Domain.Countries;

namespace Sdt.Practice.Data
{
    public class RestApiContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public RestApiContext(DbContextOptions<RestApiContext> options) : base(options)
        {

        }
    }
}