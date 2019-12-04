using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.BE.ViewModels
{
    public class AddFavoriteVM
    {
        [Required]
        public int CityKey { get; set; }
        public string LocalizedName { get; set; }
    }
}
