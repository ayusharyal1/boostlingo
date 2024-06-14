using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BoostlingoApp.Infrastructure.Repository
{
    public class RepositoryBase<T> : IRespositoryBase<T> where T : class
    {
        private readonly BoostlingoDBContext _context;

        public RepositoryBase(BoostlingoDBContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entity)
        {
            _context.Set<T>().AddRange(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => _context.Set<T>());
        }

        public void Truncate<T>() 
        {
            var tableName = typeof(T).Name.Replace("Entity", "");
            _context.Database.ExecuteSqlRaw($"TRUNCATE TABLE [dbo].[{tableName}];");
        }
    }
}
