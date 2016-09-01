using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MojeDemotywatory.Models;
using MojeDemotywatoryApi.Models;
using MojeDemotywatoryDatabaseApi;

namespace MojeDemotywatory.Controllers
{
    public class FavoriteController : Controller
    {
        public IFavoritesDemotivatorApi FavoritesDemotivatorApi { get; private set; } = new FavoritesDemotivatorApi();

        public ActionResult Index()
        {
            var favorites = FavoritesDemotivatorApi.Get().ToList();

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

        public ActionResult Remove(string url)
        {
            var favorites = FavoritesDemotivatorApi.Get().SingleOrDefault(f => f.Url == url);

            if (favorites != null)
            {
                this.FavoritesDemotivatorApi.Remove(favorites.Id);
            }

            return RedirectToAction("Index");
        }

    }
}
