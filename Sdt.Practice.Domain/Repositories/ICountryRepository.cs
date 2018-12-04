using System.Linq;
using Sdt.Practice.Domain.Models;

namespace Sdt.Practice.Domain.Repositories
{
    public interface ICountryRepository
    {
        IQueryable<Country> GetAll();
    }
}