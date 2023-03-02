using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my_flyer_back.Models;
using my_flyer_back.TafMetarClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace my_flyer_back.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly ITafMetarClient client;

        public WeatherController(ILogger<WeatherController> logger, ITafMetarClient tafMetarClient)
        {
            _logger = logger;
            client = tafMetarClient;
        }

        [HttpGet("metars")]
        public async Task<List<String>> GetMetars()
        {
           
            List<String> metars = await client.GetMetars("LMML");

            return metars;
        }

        [HttpGet("tafs")]
        public async Task<List<String>> GetTafs()
        {
            List<String> tafs = await client.GetTafs("LMML");

            return tafs;
        }

    }
}
