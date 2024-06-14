using BoostlingoApp.Domain.Entities;

namespace BoostlingoApp.Infrastructure.Repository
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(BoostlingoDBContext context) : base(context) { }
        public Task<IEnumerable<UserEntity>> GetSortedAsync()
        {
            throw new NotImplementedException();
        }
    }
}
