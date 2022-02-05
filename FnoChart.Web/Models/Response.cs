using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FnoChart.Web.Models
{
    public class Data
    {
        public List<List<object>> candles { get; set; }
    }
    public class Root
    {
        public string status { get; set; }
        public Data data { get; set; }
    }
    
    public class Rows
    {
        public object dt { get; set; }
        public object price { get; set; }
        public object pe { get; set; }

    }
}
