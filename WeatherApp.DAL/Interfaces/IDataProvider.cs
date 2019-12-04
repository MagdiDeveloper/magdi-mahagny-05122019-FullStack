using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.DAL.Bases
{
    public  interface IDataProvider<Request, Response> 
    {
        List<Response> Get(Request request); 
    }
}
