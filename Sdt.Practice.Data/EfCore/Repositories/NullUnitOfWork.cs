using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Data.EfCore.Repositories
{
    public class NullUnitOfWork : IUnitOfWork
    {
        public int SaveChanges()
        {
            return default(int);
        }
    }
}