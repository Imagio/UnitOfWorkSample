using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Ru.Rubinst.DocumentCommon
{
    public class UnitOfWork<TDbContext>: IUnitOfWork where TDbContext : DbContext
    {
        public UnitOfWork(TDbContext context)
        {
            _context = context;
        }

        private readonly TDbContext _context;

        public void Save()
        {
            _context.SaveChanges();
        }

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class 
        {
            var type = typeof (TEntity);
            if (!_repositories.ContainsKey(type))
                _repositories.Add(type, new Repository<TEntity>(_context));
            return _repositories[type] as IRepository<TEntity>;

        }

        #region IDisposable

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
