using Dtos.Converter.NumeralToWordConverter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CConverterClient.Utils
{
    public class APIConsumer : IDisposable
    {
        private HttpClient _httpClient;
        public string ConverterEndpoint { get; private set; } = null!;
        public string Host { get; private set; } = null!;

        public APIConsumer()
        {
            _httpClient = new HttpClient();
        }

        public void Configure(string host, string converterEndpoint)
        {
            this.Host = host;
            this.ConverterEndpoint = converterEndpoint;
            this._httpClient.BaseAddress = new Uri(host);
        }

        public async Task<string?> Convert (double value)
        {
            try
            {
                NumeralToWordRequest bodyContent = new NumeralToWordRequest() { Value = value };
                string body = JsonConvert.SerializeObject(bodyContent);
                StringContent requestBody = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(ConverterEndpoint, requestBody);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return null;

                var resultBody = await response.Content.ReadAsStringAsync();
                NumeralToWordResponse? resultContent = JsonConvert.DeserializeObject<NumeralToWordResponse>(resultBody);
                return resultContent?.Value;
            }
            catch
            {
                return null;
            }
        }


        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
