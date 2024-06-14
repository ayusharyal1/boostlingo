using BoostlingoApp.Domain.Models;
using System.Text.Json;
using System.Configuration;

namespace BoostlingoApp.Infrastructure.Services
{
    public class JsonDataHttpGateway() : IJsonDataHttpGateway
    {
        // Dependency Injection
        private readonly HttpClient _httpClient = new HttpClient();

        //Newtonsoft Dependency Injection
        //IOptions Pattern

        public async Task<IEnumerable<User>> GetJsonDataQueryAsync()
        {
            string dataUrl = ConfigurationManager.AppSettings["DataUrl"];
            if (string.IsNullOrEmpty(dataUrl)) throw new Exception("JsonData Url has not been configured.Please check your app.config");

            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.Method = HttpMethod.Get;
                httpRequestMessage.RequestUri = new Uri(dataUrl);
                var result = await _httpClient.SendAsync(httpRequestMessage);
                var jsonString = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<User>>(jsonString);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
