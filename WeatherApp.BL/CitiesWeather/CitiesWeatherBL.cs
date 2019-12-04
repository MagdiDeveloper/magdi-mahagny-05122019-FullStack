using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.BE.Models;
using WeatherApp.BE.ViewModels;
using WeatherApp.BL.Bases;
using WeatherApp.DAL.Bases;
using WeatherApp.DAL.Database;
using WeatherApp.DAL.Services;
using WeatherApp.Tools;

namespace WeatherApp.BL.Weather
{
    public class CitiesWeatherBL : ServiceBLBase
    {
        public List<CityModel> SearchCity(SearchCityVM vm)
        {
            string apiLocation = "Accuweather.Api.Location".GetWebConfigValue<string>();
            apiLocation += "?apikey=" + base.apiKey + "&q=" + vm.Query;
            return new DAL.Services.ServiceProvider<CityModel>().Get(apiLocation);
        }

        public WeatherVM GetWeather(GetCityWeatherVM vm)
        {
            WeatherVM weatherVM = new WeatherVM();
            DatabaseProvider<WeatherVM> dataBaseProvider = new DatabaseProvider<WeatherVM>();
            base.command.CommandText = "GetCityWeather";
            base.command.Parameters.AddWithValue("@p_CityKey", vm.CityKey);
            var result = dataBaseProvider.Get(base.command);
            if (result.Count == 0)
            {
                ServiceProvider<WeatherModel> dataServiceProvider = new ServiceProvider<WeatherModel>();
                string apiCurrentConditions = "Accuweather.Api.CurrentConditions".GetWebConfigValue<string>();
                apiCurrentConditions += vm.CityKey + "?apikey=" + base.apiKey;
                WeatherModel weatherModel = dataServiceProvider.Get(apiCurrentConditions).Single();
                weatherVM = new WeatherVM
                {
                    CityKey = vm.CityKey,
                    WeatherText = weatherModel.WeatherText,
                    Temperature = weatherModel.Temperature.Metric.Value
                };
                base.command.CommandText = "InsertCityWeather";
                base.command.Parameters.Clear();
                base.command.Parameters.AddWithValue("@p_CityKey", weatherVM.CityKey);
                base.command.Parameters.AddWithValue("@p_WeatherText", weatherVM.WeatherText);
                base.command.Parameters.AddWithValue("@p_Temperature", weatherVM.Temperature);
                dataBaseProvider.Insert(base.command);

            }
            else
            {
                weatherVM = result.FirstOrDefault();
            }
            return weatherVM;

        }
    }
}
