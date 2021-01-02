using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRealTimeCharts
{
    public class Coordinate
    {
        public double x { get; set; }
        public double y { get; set; }
        public string sensorName { get; set; }

        public Coordinate(double x, double y, string sensorName)
        {
            this.x = x;
            this.y = y;
            this.sensorName = sensorName;
        }
    }
}
