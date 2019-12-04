using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.BE.ViewModels
{
    public class RemoveFavoriteVM
    {
        [Required]
        public int Key { get; set; }
    }
}
