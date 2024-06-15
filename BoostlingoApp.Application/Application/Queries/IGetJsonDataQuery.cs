using BoostlingoApp.Domain.Models;

namespace BoostlingoApp.Application.Queries
{
    public interface IGetJsonDataQuery
    {
        /// <summary>
        /// Method to fetch all the user for Microsoft api.
        /// </summary>
        /// <returns>List of users.</returns>
        Task<IEnumerable<User>> Execute();
    }
}
