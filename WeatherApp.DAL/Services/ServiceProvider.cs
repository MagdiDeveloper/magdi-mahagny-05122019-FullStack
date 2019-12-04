using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DAL.Bases;
using WeatherApp.Tools;
using WeatherApp.Tools.Tools;

namespace WeatherApp.DAL.Services
{
    public class ServiceProvider<Response> : IDataProvider<string, Response>
    {
        public List<Response> Get(string url)
        {
            return HttpConnectors.Rest.Get<List<Response>>(url);
        }
    }
}
