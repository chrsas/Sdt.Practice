using System.Linq;
using Sdt.Practice.Domain.Models;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Data.EfCore.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly RestApiContext _context;
        public CountryRepository(RestApiContext context)
        {
            _context = context;
        }

        public IQueryable<Country> GetAll()
        {
            return _context.Countries.AsQueryable();
        }
    }
}