using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Data.EfCore.Repositories
{
    class Repository<T> : IRepository<T> where T : class
    {
        private readonly RestApiContext _context;

        public Repository(RestApiContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
