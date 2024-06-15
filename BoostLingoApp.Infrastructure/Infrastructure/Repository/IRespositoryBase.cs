namespace BoostlingoApp.Infrastructure.Repository
{
    public interface IRespositoryBase<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        void Truncate<T>();
    }
}
