using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRealTimeCharts
{
    class Point
    {
        public double lt, ln, r;
        public Point(double lt, double ln, double r) { this.lt = lt; this.ln = ln; this.r = r; }
        public double glt() { return lt; }
        public double gln() { return ln; }
        public double gr() { return r; }

        public string ToString() { return "Body:{" + lt.ToString() + ", " + ln.ToString() + ", " + r.ToString() + "}";}
    }
}
