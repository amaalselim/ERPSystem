namespace ERP.Application.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IServices<T> Repository<T>() where T : class;
        Task<int> CompleteAsync();

    }
}
