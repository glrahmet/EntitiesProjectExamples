using DataAccess.Context;
using EntitiesProject.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _applicationContext;
        public Repository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _applicationContext.Set<T>().AddAsync(entity, cancellationToken);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _applicationContext.Set<T>().FindAsync(expression, cancellationToken);
        }

        public IQueryable<T> GetAll()
        {
            return _applicationContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public IQueryable<T> GetFindExpression(Expression<Func<T, bool>> expression)
        {
            return _applicationContext.Set<T>().Where(expression).AsQueryable();
        }

        public void Remove(T entity)
        {
            _applicationContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _applicationContext.Set<T>().Update(entity);
        }
    }
}