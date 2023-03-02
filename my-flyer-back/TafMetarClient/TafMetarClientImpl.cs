using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace my_flyer_back.TafMetarClient
{
    public class TafMetarClientImpl : ITafMetarClient
    {
        private static readonly HttpClient client;

        static TafMetarClientImpl()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.met.no")
            };
        }

        public async Task<String> GetMetars(String icao)
        {
            var url = string.Format("/weatherapi/tafmetar/1.0/metar?icao={0}", icao);
            String result = "";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                String stringResponse = await response.Content.ReadAsStringAsync();

                result = stringResponse;//JsonSerializer.Deserialize<List<String>>(stringResponse, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
