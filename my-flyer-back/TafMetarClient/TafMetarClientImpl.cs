using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
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

        public async Task<List<String>> GetMetars(String icao)
        {
            var url = string.Format("/weatherapi/tafmetar/1.0/metar?icao={0}", icao);
            var response = await client.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                String stringResponse = await response.Content.ReadAsStringAsync();

                return SplitStringByLineFeed(stringResponse);//JsonSerializer.Deserialize<List<String>>(stringResponse, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

        }

        public async Task<List<String>> GetTafs(String icao)
        {
            var url = string.Format("/weatherapi/tafmetar/1.0/taf?icao={0}", icao);
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                String stringResponse = await response.Content.ReadAsStringAsync();

                return SplitStringByLineFeed(stringResponse);//JsonSerializer.Deserialize<List<String>>(stringResponse, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

        }

        private List<String> SplitStringByLineFeed(string inpString)
        {
            List<String> locResult = new List<String>(Regex.Split(inpString, "[\r\n]+"));
            return locResult;
        }
    }
}
