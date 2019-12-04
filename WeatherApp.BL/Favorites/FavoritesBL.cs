using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.BE.Models;
using WeatherApp.BE.ViewModels;
using WeatherApp.BL.Bases;

namespace WeatherApp.BL.Favorites
{
    public class FavoritesBL : BLBase
    {
        public List<FavoriteModel> GetMyFavorites()
        {
            base.command.CommandText = "GetMyFavorites";
            return new DAL.Database.DatabaseProvider<FavoriteModel>().Get(command);
        }

        public bool AddFavorite(AddFavoriteVM vm)
        {
            base.command.CommandText = "InsertFavorite";
            base.command.Parameters.AddWithValue("@p_CityKey", vm.CityKey);
            base.command.Parameters.AddWithValue("@p_LocalizedName", vm.LocalizedName);
            return new DAL.Database.DatabaseProvider<bool>().Insert(command);
        }
        public bool RemoveFavorite(RemoveFavoriteVM vm)
        {
            base.command.CommandText = "Remove";
            base.command.Parameters.AddWithValue("@p_Key", vm.Key);
            return new DAL.Database.DatabaseProvider<bool>().Remove(command);
        }
    }
}
