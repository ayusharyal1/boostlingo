using BoostlingoApp.Domain.Models;
using BoostlingoApp.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BoostlingoApp.Application.Queries
{
    public class GetJsonDataQueryHandler(IJsonDataHttpGateway jsonDataService, ILogger<GetJsonDataQueryHandler> logger) : IGetJsonDataQuery
    {
        public async Task<List<User>> Execute()
        {
            try
            {
                logger.LogInformation("Start fetching data from api.");
                return await jsonDataService.GetJsonDataQueryAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Could not fetch json data Message:{JsonSerializer.Serialize(ex)}");
                throw new Exception($"Could not fetch json data Message:{JsonSerializer.Serialize(ex)}");

            }
        }
    }
}
