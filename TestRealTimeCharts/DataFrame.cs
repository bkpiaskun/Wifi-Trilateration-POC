using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRealTimeCharts
{
    public class DataFrame
    {
        public string _id { get; set; }
        public string ssid { get; set; }
        public string sensorID { get; set; }
        public string date { get; set; }
        public int rssi { get; set; }
    }
}
