using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.BE.Models
{
    [JsonObject]
    public class WeatherModel
    {
        [JsonProperty]
        public string Key { get; set; }
        [JsonProperty]
        public string WeatherText { get; set; }
        [JsonProperty]
        public Temperature Temperature { get; set; }
    }
    [JsonObject]
    public class Temperature {
       public Metric Metric { get; set; }
    }
    [JsonObject]
    public class Metric
    {
        [JsonProperty]
        public decimal Value { get; set; }
    }
}
