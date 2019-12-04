using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.BE.ViewModels
{
    public class SearchCityVM
    {
        [Required(ErrorMessage ="query parameter cannot be empty!")]
        [StringLength(50,ErrorMessage ="query length should be 50 chars at least!")]
        public string Query { get; set; }
    }
}
