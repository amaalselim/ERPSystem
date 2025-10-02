
namespace ERP.Application.IServices
{
    public interface IServices<T> where T : class
    {
        Task<bool> SaveAsync(T entity); //return true or false
                                        // Task<(bool ISave,string msg)> SaveDataAsync(T entity); return true or false,resultmsg
        Task<bool> SaveRangeAsync(List<T> entities);

        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateRangeAsync(List<T> entities);

        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteRangeAsync(List<T> entities);

        Task<T?> GetItemAsync(Expression<Func<T, bool>> match);
        Task<T?> GetByIdAsync(int id);

        Task<bool> ExistAsync(Expression<Func<T, bool>> match);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> match);
        Task<IQueryable<T>> GetAllQueryable(Expression<Func<T, bool>> match);
        Task<int> CountAsync(Expression<Func<T, bool>> match);

        IQueryable<T> GetSelectedQueryable(Expression<Func<T, bool>> match, Expression<Func<T, T>> Selector);

    }
}
