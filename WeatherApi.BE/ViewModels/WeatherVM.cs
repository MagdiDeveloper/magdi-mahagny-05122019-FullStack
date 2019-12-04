using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.BE.ViewModels
{
    public class WeatherVM
    {
        public int CityKey { get; set; }
        public string WeatherText { get; set; }
        public decimal Temperature { get; set; }
        public bool IsFavorite { get; set; }
    }
}
