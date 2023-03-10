using CUSTInformation_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CUSTInformation_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static Uri Baseurl = new Uri("https://localhost:7017/");
        static HttpClient client = new HttpClient();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        [HttpPost]
        public async Task<IActionResult> Search(string customer)
        {
            var resultedViewModel = new List<ResultViewModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = Baseurl;
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = new HttpResponseMessage();
                response = await client.GetAsync(Baseurl + "api/Purchases/GetPurchaseFileRecords");
                var returnedJson = await response.Content.ReadAsStringAsync();
                resultedViewModel = JsonConvert.DeserializeObject<List<ResultViewModel>>(returnedJson);
            }
            return PartialView("_ResultPage", resultedViewModel);
        }
    }
}