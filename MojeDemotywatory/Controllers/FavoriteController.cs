using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MojeDemotywatory.Models;
using MojeDemotywatoryApi.Models;
using MojeDemotywatoryDatabaseApi;
using MojeDemotywatoryDatabaseApi.Dto;

namespace MojeDemotywatory.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoritesDemotivatorApi favoritesDemotivatorApi;

        public FavoriteController(IFavoritesDemotivatorApi favoritesDemotivatorApi)
        {
            this.favoritesDemotivatorApi = favoritesDemotivatorApi;
        }

        public ActionResult Index()
        {
            var favorites = favoritesDemotivatorApi.Get().ToList();

            var pageModel = new PageModel
            {
                FavoriteCount = favorites.Count,
                DemotivatorList = favorites.Select(f=> new Demotivator
                {
                    ImgUrl = f.ImgUrl,
                    Url = f.Url
                }).ToList()
            };

            return View(pageModel);
        }

        public ActionResult SaveFavorite(string url, string imgUrl)
        {
            this.favoritesDemotivatorApi.Add(new Favorites
            {
                ImgUrl = imgUrl,
                Url = url,
                User = new User
                {
                    Name = HttpContext.User.Identity.Name
                }
            });

            return RedirectToAction("Index", "Demotivator");
        }

        public ActionResult Remove(string url)
        {
            var favorites = favoritesDemotivatorApi.Get().SingleOrDefault(f => f.Url == url);

            if (favorites != null)
            {
                this.favoritesDemotivatorApi.Remove(favorites.Id);
            }

            return RedirectToAction("Index");
        }

    }
}
