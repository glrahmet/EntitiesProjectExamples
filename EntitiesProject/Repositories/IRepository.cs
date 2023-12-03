using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesProject.Repositories
{
    public interface IRepository<T>
    {
        // asekron olan işlemler cancel etmemiz için entity framework olarak uygundur prarametre olarak vermemize gerek yok 
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Remove(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        IQueryable<T> GetAll();
        IQueryable<T> GetFindExpression(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<T> GetFindFirstExpression(Expression<Func<T, bool>> expression); 
        bool Any(Expression<Func<T, bool>> expression);

    }
}
