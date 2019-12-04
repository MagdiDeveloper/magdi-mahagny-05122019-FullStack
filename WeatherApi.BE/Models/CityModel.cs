using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.BE.Models
{
    [JsonObject]
    public class CityModel
    {
        [JsonProperty]
        public string Key { get; set; }
        [JsonProperty]
        public string LocalizedName { get; set; }
    }
}
