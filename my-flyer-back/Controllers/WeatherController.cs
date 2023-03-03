using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my_flyer_back.Models;
using my_flyer_back.TafMetarClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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
        public async Task<IActionResult> GetMetars(String icao)
        {
           
            List<String> metars = await client.GetMetars(icao);

            return Ok(metars);
        }

        [HttpGet("tafs")]
        public async Task<IActionResult> GetTafs(String icao)
        {
            List<String> tafs = await client.GetTafs(icao);

            return Ok(tafs);
        }
        
        [HttpGet("metar")]
        public async Task<IActionResult> GetMetar(String icao)
        {
            List<String> metars = await client.GetMetars(icao);

            if (!metars.Any())
            {
                return Ok("");
            }

            return Ok(metars.Last());
        }

        [HttpGet("taf")]
        public async Task<IActionResult> GetTaf(String icao)
        {
            List<String> tafs = await client.GetTafs(icao);
            if (!tafs.Any())
            {
                return Ok("");
            }
            return Ok(tafs.Last());
        }
    }
}
