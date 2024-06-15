using BoostlingoApp.Domain.Models;
using BoostlingoApp.Infrastructure.Services;
using Microsoft.Extensions.Logging;

namespace BoostlingoApp.Application.Queries
{
    public class GetJsonDataQueryHandler(IJsonDataHttpGateway jsonDataGateway, ILogger<GetJsonDataQueryHandler> logger) : IGetJsonDataQuery
    {
        public async Task<IEnumerable<User>> Execute()
        {
            try
            {
                logger.LogInformation("Start fetching data from api.");
                return await jsonDataGateway.GetJsonDataQueryAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Could not fetch json data Message:{ex.Message}");
                throw new Exception($"Could not fetch json data Message:{ex.Message}");
            }
        }
    }
}
