using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WeatherApp.BE.Models;
using WeatherApp.BE.ViewModels;
using WeatherApp.BL.Favorites;

namespace WeatherApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/favorites")]
    public class FavoritesController : ApiController
    {
        [Route("")]
        public HttpResponseMessage GetMyFavorites()
        {
            if (ModelState.IsValid)
            {
                FavoritesBL favoritesBL = new FavoritesBL();
                List<FavoriteModel> favorites = favoritesBL.GetMyFavorites();
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Data = favorites
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotImplemented);
            }
        }
        [Route("Insert")]
        public HttpResponseMessage PostAddToFavorite([FromBody]AddFavoriteVM model)
        {
            if (ModelState.IsValid)
            {
                FavoritesBL favoritesBL = new FavoritesBL();
                bool isSuccess = favoritesBL.AddFavorite(model);

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Data = isSuccess,
                    Message = !isSuccess ? "an error accours while trying to save favorite!" : string.Empty
                });

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotImplemented);
            }
        }


        [Route("Remove")]
        public HttpResponseMessage DeleteFavorite([FromBody]RemoveFavoriteVM model)
        {
            if (ModelState.IsValid)
            {
                FavoritesBL favoritesBL = new FavoritesBL();
                bool isSuccess = favoritesBL.RemoveFavorite(model);

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Data = isSuccess,
                    Message = !isSuccess ? "an error accours while trying to remove favorite!" : string.Empty
                });

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotImplemented);
            }
        }
    }
}