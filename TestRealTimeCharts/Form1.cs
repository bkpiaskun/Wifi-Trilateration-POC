using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace TestRealTimeCharts
{
    public partial class Form1 : Form
    {
        private readonly string servername = "https://wifilocalizer.herokuapp.com/api/sensors";

        private Thread cpuThread;

        private List<Coordinate> coordinates;

        public Form1()
        {
            InitializeComponent();
        }

        private void getPerformanceCounters()
        {
            coordinates = fetchData();
            if (cpuChart.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
            }
            Thread.Sleep(500);
        }

        private void UpdateCpuChart()
        {
            cpuChart.Series.Clear();

            for (int i = 0; i < coordinates.Count; ++i)
            {
                System.Windows.Forms.DataVisualization.Charting.Series serie = new System.Windows.Forms.DataVisualization.Charting.Series(coordinates[i].sensorName);
                serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                try
                {
                    Console.WriteLine(coordinates[i].x);
                    Console.WriteLine(coordinates[i].y);

                    if (!cpuChart.Series.Contains(serie))
                        cpuChart.Series.Add(serie);
                    cpuChart.Series[coordinates[i].sensorName].Points.Clear();
                    cpuChart.Series[coordinates[i].sensorName].Points.AddXY(coordinates[i].x, coordinates[i].y);
                }
                catch
                { 

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cpuThread == null)
            {
                cpuThread = new Thread(new ThreadStart(this.getPerformanceCounters));
                cpuThread.IsBackground = true;
                cpuThread.Start();
            }
            else
            {
                cpuThread.Join();
                cpuThread = new Thread(new ThreadStart(this.getPerformanceCounters));
                cpuThread.IsBackground = true;
                cpuThread.Start();
            }
        }

        private List<Coordinate> fetchData()
        {
            Random rnd = new Random();
            List<Coordinate> coordinates = new List<Coordinate>();
            List<Tuple<String, Tuple<double, double>>> points = GatherDataFrames(servername);
            for(int i=0;i<points.Count;i++)
            {
                coordinates.Add(new Coordinate(points[i].Item2.Item1, points[i].Item2.Item2, points[i].Item1));
            }

            /*
            public Coordinate(double x, double y, Tuple<string, int>[] rssi, string sensorName)

            coordinates[0] = new Coordinate(rnd.NextDouble(), rnd.NextDouble(), [new Tuple<string, int>("1ap", rnd.Next())], "pitok1");
            coordinates[1] = new Coordinate(rnd.NextDouble(), rnd.NextDouble(), [new Tuple<string, int>("2ap", rnd.Next())], "pitok2");
            coordinates[2] = new Coordinate(rnd.NextDouble(), rnd.NextDouble(), [new Tuple<string, int>("3ap", rnd.Next())], "pitok3");
            coordinates[3] = new Coordinate(rnd.NextDouble(), rnd.NextDouble(), [new Tuple<string, int>("4ap", rnd.Next())], "pitok4");
            */

            return coordinates;
        }

        private List<Tuple<String,Tuple<double,double>>> GatherDataFrames(string servername)
        {
            List<Tuple<String, Tuple<double, double>>> points = new List<Tuple<String, Tuple<double,double>>>();
            List<DataFrame> dataFrames = Connect.Get(servername);

            string lastSsid = "";
            List<Point> tempPoints = new List<Point>();


            foreach (DataFrame frame in dataFrames)
            {   
                if(lastSsid == frame.ssid)
                {
                    /*
tempPoints.Add(new Point(
    Double.Parse(sens1x.Text, CultureInfo.InvariantCulture),
    Double.Parse(sens1y.Text, CultureInfo.InvariantCulture),
    frame.rssi)
    );
*/

                    switch (tempPoints.Count)
                    {
                        case 0:
                            tempPoints.Add(new Point(
                                Double.Parse(sens1x.Text, CultureInfo.InvariantCulture) + 0.0001f,
                                Double.Parse(sens1y.Text, CultureInfo.InvariantCulture) + 0.0001f,
                                frame.rssi + 10000)
                                );
                            break;
                        case 1:
                            tempPoints.Add(new Point(
                                Double.Parse(sens2x.Text, CultureInfo.InvariantCulture) + 0.0001f,
                                Double.Parse(sens2y.Text, CultureInfo.InvariantCulture) + 0.0001f,
                                frame.rssi + 10000)
                                );
                            break;
                        case 2:
                            tempPoints.Add(new Point(
                                Double.Parse(sens3x.Text, CultureInfo.InvariantCulture) + 0.0001f,
                                Double.Parse(sens3y.Text, CultureInfo.InvariantCulture) + 0.0001f,
                                frame.rssi + 10000)
                                );
                            break;
                        case 3:
                            tempPoints.Add(new Point(
                                Double.Parse(sens4x.Text, CultureInfo.InvariantCulture) + 0.0001f,
                                Double.Parse(sens4y.Text, CultureInfo.InvariantCulture) + 0.0001f,
                                frame.rssi+10000)
                                );
                            break;
                    }

                    Point p1 = new Point(-19.6685, -69.1942, 84);
                    Point p2 = new Point(-20.2705, -70.1311, 114);
                    Point p3 = new Point(-20.5656, -70.1807, 120);
                    double[] a = Trilateration.Compute(p1, p2, p3);
                    Console.WriteLine("LatLon: " + a[0] + ", " + a[1]);


                    if (tempPoints.Count == 4)
                    {
                        double sumY = 0, sumX = 0;
                        double[] tempPoint1, tempPoint2, tempPoint3, tempPoint4;
                        tempPoint1 = Trilateration.Compute(tempPoints[0], tempPoints[1], tempPoints[2]);
                        tempPoint2 = Trilateration.Compute(tempPoints[0], tempPoints[1], tempPoints[3]);
                        tempPoint3 = Trilateration.Compute(tempPoints[0], tempPoints[2], tempPoints[3]);
                        tempPoint4 = Trilateration.Compute(tempPoints[1], tempPoints[2], tempPoints[3]);
                        sumX = tempPoint1[0] + tempPoint2[0] + tempPoint3[0] + tempPoint4[0];
                        sumY = tempPoint1[1] + tempPoint2[1] + tempPoint3[1] + tempPoint4[1];



                        if (!Double.IsNaN(sumX / 4) && !Double.IsNaN(sumY / 4))
                        {
                            points.Add(new Tuple<string, Tuple<double, double>>(frame.ssid, new Tuple<double, double>(sumX / 4, sumY / 4)));
                            points.Add(new Tuple<string, Tuple<double, double>>("Sensor 1", new Tuple<double, double>(Double.Parse(sens1x.Text, CultureInfo.InvariantCulture), Double.Parse(sens1y.Text, CultureInfo.InvariantCulture))));
                            points.Add(new Tuple<string, Tuple<double, double>>("Sensor 2", new Tuple<double, double>(Double.Parse(sens2x.Text, CultureInfo.InvariantCulture), Double.Parse(sens2y.Text, CultureInfo.InvariantCulture))));
                            points.Add(new Tuple<string, Tuple<double, double>>("Sensor 3", new Tuple<double, double>(Double.Parse(sens3x.Text, CultureInfo.InvariantCulture), Double.Parse(sens3y.Text, CultureInfo.InvariantCulture))));
                            points.Add(new Tuple<string, Tuple<double, double>>("Sensor 4", new Tuple<double, double>(Double.Parse(sens4x.Text, CultureInfo.InvariantCulture), Double.Parse(sens4y.Text, CultureInfo.InvariantCulture))));
                        }
                        tempPoints.Clear();
                    }
                } 
                else
                {
                    tempPoints.Clear();

                    tempPoints.Add(new Point(
                        Double.Parse(sens1x.Text, CultureInfo.InvariantCulture)+0.0001f,
                        Double.Parse(sens1y.Text, CultureInfo.InvariantCulture) + 0.0001f,
                        frame.rssi + 10000)
                        );
                    lastSsid = frame.ssid;
                }
            }
            return points;
        }
    }
}