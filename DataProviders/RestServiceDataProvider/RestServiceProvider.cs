using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AggregateReader.DataProviders.RestServiceDataProvider
{
    public class RestServiceProvider(UrlConfig urlConfig) : IDataProvider
    {
        public UrlConfig UrlConfig { get; private set; } = urlConfig;

        public async Task<string> GetDataAsync(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response;

                if (UrlConfig.Method.ToUpper() == "GET")
                {
                    string url = UrlConfig.Url.Replace("[[id]]", id);
                    response = await client.GetAsync(url);
                }
                else // POST
                {
                    string body = UrlConfig.BodyTemplate.Replace("[[id]]", id);
                    response = await client.PostAsync(UrlConfig.Url, new StringContent(body, Encoding.UTF8, "application/json"));
                }

                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                string base64Content = ExtractBase64Content(jsonResponse, UrlConfig.JsonPath);

                return Encoding.UTF8.GetString(Convert.FromBase64String(base64Content));
            }
        }

        private string ExtractBase64Content(string jsonResponse, string jsonPath)
        {
            var jObject = Newtonsoft.Json.Linq.JObject.Parse(jsonResponse);
            var token = jObject.SelectToken(jsonPath);
            return token?.ToString();
        }
    }
}
