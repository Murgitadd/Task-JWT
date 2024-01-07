using Microsoft.EntityFrameworkCore;
using ProniaOnionAlpha.Application.Abstractions.Repositories;
using ProniaOnionAlpha.Domain;
using ProniaOnionAlpha.Persistence.Contexts;
using System.Linq.Expressions;

namespace ProniaOnionAlpha.Persistence.Implementations.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _table = context.Set<T>();
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            T? entity = await _table.FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }
        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _table.Update(entity);
        }
        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            _table.Update(entity);
        }
        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAllAsync(
            Expression<Func<T, bool>>? expression = null, 
            Expression<Func<T, object>>? orderExpression = null, 
            bool IsDescending = false, 
            int skip = 0, 
            int take = 0, 
            bool IsTracking = true,
            bool IsDeleted = false,
            params string[] includes)
        {
            var query = _table.AsQueryable();

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            if (orderExpression is not null)
            {
                if (IsDescending) query = query.OrderByDescending(orderExpression);
                else query = query.OrderBy(orderExpression);
            }

            if (skip != 0) query = query.Skip(skip);

            if (take != 0) query = query.Take(take);

            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (IsDeleted) query = query.IgnoreQueryFilters();
            return IsTracking ? query : query.AsNoTracking();
        } 
    }
}
