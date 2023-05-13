using Dtos.Convert.NumberToWord;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CConverterClient.Utils
{
    public class APIConsumer : IDisposable
    {
        private string Host = null!;
        private string ConvertEndpoint = null!;
        private readonly HttpClient Client;

        public APIConsumer()
        {
            Client = new HttpClient();
        }

        public void Configure(string host, string convertEndpoint)
        {
            this.Host = host;
            this.ConvertEndpoint = convertEndpoint;

            this.Client.BaseAddress = new Uri(Host);
        }

        public async Task<string?> Convert(double number)
        {
            NumberToWordRequest request = new NumberToWordRequest() { Value = number };
            string requestBody = JsonConvert.SerializeObject(request);

            StringContent requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(ConvertEndpoint, requestContent);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            string responseBody = await response.Content.ReadAsStringAsync();
            NumberToWordResponse? ntwResponse = JsonConvert.DeserializeObject<NumberToWordResponse>(responseBody);

            return ntwResponse?.Value;
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
