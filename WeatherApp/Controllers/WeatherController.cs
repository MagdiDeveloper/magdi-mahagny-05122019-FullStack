using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WeatherApp.BE.ViewModels;
using WeatherApp.BL.Weather;

namespace WeatherApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/weather")]
    public class WeatherController : ApiController
    {

        [Route("{CityKey}/city")]
        public HttpResponseMessage GetByCityKey([FromUri]GetCityWeatherVM model)
        {
            if (ModelState.IsValid)
            {
                CitiesWeatherBL citiesWeatherBL = new CitiesWeatherBL();
                WeatherVM weatherVM = citiesWeatherBL.GetWeather(model);
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Data = weatherVM
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotImplemented);
            }
        }

    }
}