using BoostlingoApp.Domain.Models;

namespace BoostlingoApp.Infrastructure.Services
{
    public interface IJsonDataHttpGateway
    {
        /// <summary>
        /// Method to fetch json data and parse into user object.
        /// </summary>
        /// <returns>List of users.</returns>
        Task<List<User>> GetJsonDataQueryAsync();
    }
}
