
using GrapePulseAPI.Data;
using GrapePulseAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GradePulseAPI.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SchoolDBContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(SchoolDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();            
        }
        public async Task<int> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await _context.SaveChangesAsync();            
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
           return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }
    }
}
