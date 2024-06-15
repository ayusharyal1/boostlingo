using BoostlingoApp.Domain.Models;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace BoostlingoApp.Infrastructure.Services
{
    public class JsonDataHttpGateway(HttpClient httpClient, IConfiguration config) : IJsonDataHttpGateway
    {
        public async Task<IEnumerable<User>> GetJsonDataQueryAsync()
        {
            string dataUrl = config.GetSection("DataUrl").Value;
            if (string.IsNullOrEmpty(dataUrl)) throw new Exception("DataUrl has not been configured.Please check your app.config");
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.RequestUri = new Uri(dataUrl);
            var result = await httpClient.SendAsync(httpRequestMessage);
            var jsonString = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<User>>(jsonString);
            
        }
    }
}
