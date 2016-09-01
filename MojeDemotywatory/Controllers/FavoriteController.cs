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
        public FavoritesDemotivatorDbApi FavoritesDemotivatorDbApi { get; private set; } = new FavoritesDemotivatorDbApi();

        public ActionResult Index()
        {
            var favorites = FavoritesDemotivatorDbApi.Get().ToList();

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
            var favorites = FavoritesDemotivatorDbApi.Get().SingleOrDefault(f => f.Url == url);

            if (favorites != null)
            {
                this.FavoritesDemotivatorDbApi.Remove(favorites.Id);
            }

            return RedirectToAction("Index");
        }

    }
}
