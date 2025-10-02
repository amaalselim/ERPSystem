namespace ERP.Infrastructure.Services
{
    public class ServiceGeneric<T>(ApplicationDbContext _context) : IServices<T> where T : class
    {
        public async Task<int> CountAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().AsNoTracking().CountAsync(match);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity is null) return false;
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRangeAsync(List<T> entities)
        {
            if (entities.Count() > 0)
            {
                _context.Set<T>().RemoveRange(entities);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<bool> ExistAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().AsNoTracking().AnyAsync(match);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().AsNoTracking().Where(match).ToListAsync();
        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().AsNoTracking().Where(match);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return id > 0 ? await _context.Set<T>().FindAsync(id) : null;
        }

        public async Task<T?> GetItemAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(match);
        }

        public IQueryable<T> GetSelectedQueryable(Expression<Func<T, bool>> match, Expression<Func<T, T>> Selector)
        {
            return _context.Set<T>().AsNoTracking().Where(match).Select(Selector);
        }

        public async Task<bool> SaveAsync(T entity)
        {
            if (entity is null) return false;
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveRangeAsync(List<T> entities)
        {
            if (entities.Count() > 0)
            {
                _context.Set<T>().AddRange(entities);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<decimal> SumAsync(Expression<Func<T, bool>> match, Expression<Func<T, decimal>> Selector)
        {
            return await _context.Set<T>().AsNoTracking().Where(match).SumAsync(Selector);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity is null) return false;
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<T> entities)
        {
            if (entities.Count() > 0)
            {
                _context.Set<T>().UpdateRange(entities);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
