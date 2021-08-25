using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.GetApi.Models;

namespace WeatherApp.GetApi
{
    public class GettingApi
    {
        private WeatherModel weather;

        public GettingApi() { }

        public WeatherModel ApiCall()
        {
            var uri = Settings.Default.Url;
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        if (stream == null) return null;
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            string responseBody = streamReader.ReadToEnd();
                            JObject json = JObject.Parse(responseBody);
                            weather = JsonConvert.DeserializeObject<WeatherModel>(responseBody);
                            return weather;
                        }
                    }
                }
            }
            catch (WebException) { return null; }
        }

    }
}
