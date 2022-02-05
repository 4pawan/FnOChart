using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FnoChart.Web.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FnoChart.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        // GET: api/<ChartController>
        [HttpGet]
        public List<Rows> Get()
        {

            var pathpe = @"C:\Users\Pawan\source\repos\FnoChart.Web\FnoChart.Web\input\FEB630PE.json";
            var feb630PE = JsonConvert.DeserializeObject<Root>(System.IO.File.ReadAllText(pathpe));

            var pathhdfcife = @"C:\Users\Pawan\source\repos\FnoChart.Web\FnoChart.Web\input\hdfcife.json";
            var hdfcife = JsonConvert.DeserializeObject<Root>(System.IO.File.ReadAllText(pathhdfcife));

            var data = new List<Rows>();

            foreach (var candle in hdfcife.data.candles)
            {
                var dt = Convert.ToDateTime(candle[0]);
                var found = feb630PE.data.candles.SingleOrDefault(d => dt == Convert.ToDateTime(d[0]));
                if (found != null)
                {
                    data.Add(new Rows { dt = dt, pe = (found[4]), price = candle[4] });
                }
                else
                {
                    data.Add(new Rows { dt = dt, pe = 0, price = candle[4] });
                }
            }
            return data;
        }

        // GET api/<ChartController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChartController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
