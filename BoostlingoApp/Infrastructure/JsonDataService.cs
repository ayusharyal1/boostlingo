using BoostlingoApp.Domain.Models;
using System.Text.Json;
using System.Configuration;

namespace BoostlingoApp.Infrastructure
{
    public class JsonDataService() : IJsonDataService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<List<User>> GetJsonDataQueryAsync()
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
                return JsonSerializer.Deserialize<List<User>>(jsonString);
            }
            catch(Exception ex)
            { 
                throw new Exception($"Exception Occured: Could not read data from url={dataUrl} Message={ex.Message}.");
            }
        }
    }
}
