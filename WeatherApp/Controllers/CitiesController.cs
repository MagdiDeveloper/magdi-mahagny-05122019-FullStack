using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WeatherApp.BE.Models;
using WeatherApp.BE.ViewModels;
using WeatherApp.BL.Weather;

namespace WeatherApp.Controllers
{
    [EnableCors(origins: "http://localhost:6061", headers: "*", methods: "*")]
    [RoutePrefix("api/cities")]
    public class CitiesController : ApiController
    {
      
        [Route("{query}/search")]
        public HttpResponseMessage GetSearchCity([FromUri]SearchCityVM model)
        {
            if (ModelState.IsValid)
            {
                CitiesWeatherBL citiesWeatherBL = new CitiesWeatherBL();
                List<CityModel> cities =  citiesWeatherBL.SearchCity(model);
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Data = cities
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotImplemented);
            }
        }

        
    }
}