using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.BE.Models
{
    public class FavoriteModel
    {
        public int CityKey { get; set; }
        public string LocalizedName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public FavoriteModel()
        {

        }
    }
}
