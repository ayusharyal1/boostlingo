using BoostlingoApp.Domain.Models;

namespace BoostlingoApp.Application.Queries
{
    public interface IGetUsersSortedByNameQuery
    {
        /// <summary>
        /// Method to fetch Users sorted by first and last name.
        /// </summary>
        /// <returns>List of Users.</returns>
        public Task<IEnumerable<User>> Execute();
    }
}
