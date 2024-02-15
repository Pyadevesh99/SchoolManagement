using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositiory.Interface
{
    public interface IGenericRepositiory<T> : IDisposable
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperty = null);

        T GetById(object id);

        Task<T> GetByIdAsync(object id);

        void Add(T entity);

        Task<T> AddSync(T entity);

        void DeleteById(object id);

        void Delete(T entity);

        Task<T> DeleteAsync(T entity);

        void update(T entity);

        Task<T> UpdateAsync(T entity);
    }
}
