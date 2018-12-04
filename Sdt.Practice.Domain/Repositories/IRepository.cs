using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sdt.Practice.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T FirstOrDefault(Expression<Func<T, bool>> expression);
    }
}