using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my_flyer_back.Models;
using my_flyer_back.TafMetarClient;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace my_flyer_back.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITafMetarClient client;

        public HomeController(ILogger<HomeController> logger, ITafMetarClient tafMetarClient)
        {
            _logger = logger;
            client = tafMetarClient;
        }

        public async Task<IActionResult> GetMetars()
        {
            String metars = "";
            metars = await client.GetMetars("LMML");

            return View(metars);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
