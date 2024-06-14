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
        Task<List<User>> GetJsonDataQueryAsync();
    }
}
