using Microsoft.Owin.Hosting;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using WeatherApp.GetApi;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;

namespace WeatherApp.Server1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            string url = "http://localhost:8080";
            using (WebApp.Start(url)) {
               
            }
        }
    }
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    [HubName("TestHub")]
    public class MyHub : Hub
    {
        public void Notify(string info)
        {
            Clients.All.SendInfo(info);
        }

        public void Notify2(bool notify)
        {
            Clients.All.SendNotify(notify);
        }
    }
}
