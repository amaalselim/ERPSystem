namespace ERP.Infrastructure.UnitOfWork
{
    public class UnitOfWork(ApplicationDbContext _context) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = new();
        public IServices<T> Repository<T>() where T : class
        {
            var type = typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repoInstance = new ServiceGeneric<T>(_context);
                _repositories.Add(type, repoInstance);
            }
            return (IServices<T>)_repositories[type];
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
