using System;
using System.Transactions;
using Sdt.Practice.Domain.Repositories;

namespace Sdt.Practice.Data.EfCore.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RestApiContext _context;

        private readonly TransactionScope _transactionScope;

        public UnitOfWork(RestApiContext context)
        {
            _context = context;
            _transactionScope = new TransactionScope();
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _transactionScope.Complete();
                    _transactionScope.Dispose();
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~UnitOfWork() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}