﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestRealTimeCharts
{
    static class Connect
    {
        static public List<DataFrame> Get(string uri)
        {
            string payload = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                payload = reader.ReadToEnd();
            }

            
            List<DataFrame> data = JsonConvert.DeserializeObject<List<DataFrame>>(payload);


            return data;
        }
    }
}
