using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
                Series serie = new Series(coordinates[i].sensorName);

                ChartArea CA = cpuChart.ChartAreas[0];
                CA.AxisX.ScaleView.Zoomable = true;
                CA.AxisY.ScaleView.Zoomable = true;
                CA.CursorX.AutoScroll = true;
                CA.CursorX.IsUserSelectionEnabled = true;
                CA.CursorY.AutoScroll = true;
                CA.CursorY.IsUserSelectionEnabled = true;
                serie.ChartType = SeriesChartType.Point;
                try
                {

                    if (!cpuChart.Series.Contains(serie))
                        cpuChart.Series.Add(serie);
                    cpuChart.Series[coordinates[i].sensorName].Points.Clear();
                    int idx = cpuChart.Series[coordinates[i].sensorName].Points.AddXY(coordinates[i].x, coordinates[i].y);
                    cpuChart.Series[coordinates[i].sensorName].MarkerStyle = MarkerStyle.Square;
                    cpuChart.Series[coordinates[i].sensorName].Points[idx].Label = coordinates[i].sensorName;
                    cpuChart.Series[coordinates[i].sensorName].ToolTip = "X: #VALX, Y: #VALY";
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


            return coordinates;
        }

        private List<Tuple<String,Tuple<double,double>>> GatherDataFrames(string servername)
        {
            List<Tuple<String, Tuple<double, double>>> points = new List<Tuple<String, Tuple<double,double>>>();
            List<DataFrame> dataFrames = Connect.Get(servername);

            string lastSsid = "";
            List<Sensor> tempPoints = new List<Sensor>();


            foreach (DataFrame frame in dataFrames)
            {   
                if(lastSsid == frame.ssid)
                {


                    switch (tempPoints.Count)
                    {
                        case 0:
                            tempPoints.Add(new Sensor(
                                Double.Parse(sens1x.Text, CultureInfo.InvariantCulture),
                                Double.Parse(sens1y.Text, CultureInfo.InvariantCulture),
                                frame.rssi)
                                );
                            break;
                        case 1:
                            tempPoints.Add(new Sensor(
                                Double.Parse(sens2x.Text, CultureInfo.InvariantCulture),
                                Double.Parse(sens2y.Text, CultureInfo.InvariantCulture),
                                frame.rssi)
                                );
                            break;
                        case 2:
                            tempPoints.Add(new Sensor(
                                Double.Parse(sens3x.Text, CultureInfo.InvariantCulture),
                                Double.Parse(sens3y.Text, CultureInfo.InvariantCulture),
                                frame.rssi)
                                );
                            break;
                        case 3:
                            tempPoints.Add(new Sensor(
                                Double.Parse(sens4x.Text, CultureInfo.InvariantCulture),
                                Double.Parse(sens4y.Text, CultureInfo.InvariantCulture),
                                frame.rssi)
                                );
                            break;
                    }

                    if (tempPoints.Count == 4)
                    {
                        double[] a = Trilateration.Trilaterate2DLinear(tempPoints[0].cords, tempPoints[1].cords, tempPoints[2].cords, tempPoints[0].distance, tempPoints[1].distance, tempPoints[2].distance);
                        double[] b = Trilateration.Trilaterate2DLinear(tempPoints[1].cords, tempPoints[2].cords, tempPoints[3].cords, tempPoints[1].distance, tempPoints[2].distance, tempPoints[3].distance);
                        double[] c = Trilateration.Trilaterate2DLinear(tempPoints[2].cords, tempPoints[3].cords, tempPoints[0].cords, tempPoints[2].distance, tempPoints[3].distance, tempPoints[0].distance);
                        double[] d = Trilateration.Trilaterate2DLinear(tempPoints[0].cords, tempPoints[1].cords, tempPoints[3].cords, tempPoints[0].distance, tempPoints[1].distance, tempPoints[3].distance);




                        double sumY = 0, sumX = 0;
                        sumX = (a[0] + b[0] + c[0] + d[0]) / 4;
                        sumY = (a[1] + b[1] + c[1] + d[1]) / 4;
                        if (frame.ssid == "Sitko") {
                             foreach (Sensor i in tempPoints)
                              {
                                  Console.WriteLine(i.ToString());
                              }
                            Console.WriteLine("LatLon: " + a[0] + ", " + a[1]);
                            Console.WriteLine("LatLon: " + b[0] + ", " + b[1]);
                            Console.WriteLine("LatLon: " + c[0] + ", " + c[1]);
                            Console.WriteLine("LatLon: " + d[0] + ", " + d[1]);
                            Console.WriteLine("LatLon: " + sumX + ", " + sumY);

                        }
                        if (sumX > -200 && sumY > -200 && sumX < 200 && sumY < 200) { 
                        points.Add(new Tuple<string, Tuple<double, double>>(frame.ssid, new Tuple<double, double>(sumX, sumY)));
                        }

                    }


                } 
                else
                {
                    tempPoints.Clear();

                    tempPoints.Add(new Sensor(
                        Double.Parse(sens1x.Text, CultureInfo.InvariantCulture),
                        Double.Parse(sens1y.Text, CultureInfo.InvariantCulture),
                        frame.rssi)
                        );
                    lastSsid = frame.ssid;
                }

            }
            points.Add(new Tuple<string, Tuple<double, double>>("Sensor 1", new Tuple<double, double>(Double.Parse(sens1x.Text, CultureInfo.InvariantCulture), Double.Parse(sens1y.Text, CultureInfo.InvariantCulture))));
            points.Add(new Tuple<string, Tuple<double, double>>("Sensor 2", new Tuple<double, double>(Double.Parse(sens2x.Text, CultureInfo.InvariantCulture), Double.Parse(sens2y.Text, CultureInfo.InvariantCulture))));
            points.Add(new Tuple<string, Tuple<double, double>>("Sensor 3", new Tuple<double, double>(Double.Parse(sens3x.Text, CultureInfo.InvariantCulture), Double.Parse(sens3y.Text, CultureInfo.InvariantCulture))));
            points.Add(new Tuple<string, Tuple<double, double>>("Sensor 4", new Tuple<double, double>(Double.Parse(sens4x.Text, CultureInfo.InvariantCulture), Double.Parse(sens4y.Text, CultureInfo.InvariantCulture))));
            return points;
        }

        private void sens1x_TextChanged(object sender, EventArgs e)
        {

        }

        private void sens3x_TextChanged(object sender, EventArgs e)
        {

        }

        private void sens2y_TextChanged(object sender, EventArgs e)
        {

        }

        private void sens2x_TextChanged(object sender, EventArgs e)
        {

        }

        private void cpuChart_Click(object sender, EventArgs e)
        {

        }
    }
}