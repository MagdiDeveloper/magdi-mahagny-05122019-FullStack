using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Tools;

namespace WeatherApp.BL.Bases
{
    public abstract class ServiceBLBase : BLBase
    {
        protected string apiKey = null;
        public ServiceBLBase() :base()
        {
            apiKey = "Accuweather.Key".GetWebConfigValue<string>();
        }
    }
}
