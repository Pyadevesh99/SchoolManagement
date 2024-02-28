using Data.Repositiory.Implementations;
using Data.Repositiory.Interface;
using Data.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepositiory<T> GenericRepositiory<T>() where T : class
        {
            IGenericRepositiory<T> genericRepositiory = new GenericRepository<T>(_context);
            return genericRepositiory;
        }

        public void save()
        {
            _context.SaveChanges();
        }



        #region IDisposable

        private bool Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.Disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
