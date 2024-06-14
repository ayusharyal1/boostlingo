using BoostlingoApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostlingoApp.Infrastructure
{
    public interface IJsonDataService
    {
        /// <summary>
        /// Method to fetch json data and parse into user object.
        /// </summary>
        /// <returns>List of users.</returns>
        Task<List<User>> GetJsonDataQueryAsync();
    }
}
