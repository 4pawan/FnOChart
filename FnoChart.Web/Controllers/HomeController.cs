using FnoChart.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FnoChart.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var pathpe = @"C:\Users\Pawan\source\repos\FnoChart.Web\FnoChart.Web\input\FEB630PE.json";
            var feb630PE = JsonConvert.DeserializeObject<Root>(System.IO.File.ReadAllText(pathpe));

            var pathhdfcife = @"C:\Users\Pawan\source\repos\FnoChart.Web\FnoChart.Web\input\hdfcife.json";
            var hdfcife = JsonConvert.DeserializeObject<Root>(System.IO.File.ReadAllText(pathhdfcife));

            var data = new List<Rows>();

            foreach (var candle in hdfcife.data.candles)
            {
                var dt =  Convert.ToDateTime(candle[0]) ;
                var found = feb630PE.data.candles.SingleOrDefault(d => dt == Convert.ToDateTime(d[0]));
                if (found != null)
                {
                    data.Add(new Rows { dt = dt, pe = (found[5]),price = candle[5]});
                }
                else
                {
                    data.Add(new Rows { dt = dt, pe = 0, price = candle[5] });
                }
            }



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
