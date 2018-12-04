using System.Linq;

namespace Sdt.Practice.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
    }
}