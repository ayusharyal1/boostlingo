using BoostlingoApp.Domain.Models;
using BoostlingoApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostlingoApp.Application.Queries
{
    public class GetJsonDataQueryHandler(IJsonDataService jsonDataService) : IGetJsonDataQuery
    {
        public async Task<List<User>> GetJsonDataQueryAsync()
        {
            return await jsonDataService.GetJsonDataQueryAsync();
        }
    }
}
