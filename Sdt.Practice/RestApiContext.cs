using Microsoft.EntityFrameworkCore;
using Sdt.Practice.Models;

namespace Sdt.Practice
{
    public class RestApiContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public RestApiContext(DbContextOptions<RestApiContext> options) : base(options)
        {

        }
    }
}