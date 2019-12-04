using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Tools;

namespace WeatherApp.BL.Bases
{
    public abstract class BLBase
    {
        protected SqlCommand command = null;
        public BLBase()
        {
            command = new SqlCommand();
        }
            
        
    }
}
