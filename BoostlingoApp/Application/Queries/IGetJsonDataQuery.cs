using BoostlingoApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostlingoApp.Application.Queries
{
    public interface IGetJsonDataQuery
    {
        /// <summary>
        /// Method to fetch all the user for Microsoft api.
        /// </summary>
        /// <returns>List of users.</returns>
        Task<List<User>> Execute();
    }
}
