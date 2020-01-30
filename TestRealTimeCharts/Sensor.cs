using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRealTimeCharts
{
    class Sensor
    {
        public double[] cords;
        public double distance;

        public Sensor(double[] cords, double rssi)
        {
            this.cords = cords;
            this.distance = Math.Pow(10, ((-54 - rssi) / (10 * 2)));
        }

        public Sensor(double a, double b, double rssi)
        {
            this.cords = new double[] {0, 0};
            this.cords[0] = a;
            this.cords[1] = b;
            this.distance = Math.Pow(10, ((-54 - rssi) / (10 * 2)));
        }

        public double[] getCords()
        {
            return cords;
        }

        public double getDistance()
        {
            return distance;
        }

        public string ToString()
        {
            return "Body: {" + cords[0] + ", " + cords[1] + ", " + distance +" }";
        }
    }
}
