using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SatelliteOffice.Models;
using SatelliteOffice.Models.COVID19;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SatelliteOffice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Settings _settings;

        public HomeController(ILogger<HomeController> logger,
            IOptions<Settings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        public IActionResult Index()
        {
            var data = getCovidUpdates().Result.Data.Rows;
            return View(data);
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


        private async Task<CovidResponse> getCovidUpdates()
        {

            using(var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                client.BaseAddress = new Uri(_settings.CovidBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(_settings.CovidTrackerEndpoint);
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<CovidResponse>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception("Sorry something went wrong");
                }

            }

        }

    }
}
