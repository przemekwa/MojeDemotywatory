﻿
using MojeDemotywatoryApi.Interface;
using MojeDemotywatoryDatabaseApi;
using MojeDemotywatoryDatabaseApi.Dto;

namespace MojeDemotywatory.Controllers
{
    using Infrastructure;
    using Models;
    using MojeDemotywatoryApi;
    using NLog;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class DemotivatorController : Controller
    {
        private readonly IDemotivatorApi demotivatorApi;

        private readonly IFavoritesDemotivatorApi favoritesDemotivatorApi; 

        private readonly ILogger log = LogManager.GetCurrentClassLogger();

        public DemotivatorController(IFavoritesDemotivatorApi favoritesDemotivatorApi, IDemotivatorApi demotivatorApi )
        {
            this.favoritesDemotivatorApi = favoritesDemotivatorApi;
            this.demotivatorApi = demotivatorApi;
        }

        public ActionResult Index()
        {
            this.log.Debug("Start aplikacji");

            var model = new PageModel
            {
                CurrentPage = 1,
                FavoriteCount = favoritesDemotivatorApi.Get().Count()
            };

            var page = this.demotivatorApi.GetPage(model.CurrentPage);

            this.log.Debug($"Pobrano {page.DemotivatorList.Count} demotów.");

            model.DemotivatorList = page.DemotivatorList.ToList();

            model.DemotivatorSlideList = page.DemotivatorSlajdList.ToList();

            return View(model);
        }

        [HandleError(ExceptionType = typeof(NullReferenceException), View = "PageNotExist")]
        public ActionResult GetNextPage(int pageNumber = 1)
        {
            var page = this.demotivatorApi.GetPage(++pageNumber);

            var model = new PageModel
            {
                CurrentPage = pageNumber,
                DemotivatorList = page.DemotivatorList.ToList(),
                DemotivatorSlideList = page.DemotivatorSlajdList.ToList()
            };
         
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Page", model);
            }

            return View("Index", model);
        }

        [OutOfRangeSlide]
        public ActionResult GetRandomPage()
        {
            var model = new PageModel();

            var random = new Random();

            model.CurrentPage = random.Next(model.CurrentPage, 10000);

            var page = this.demotivatorApi.GetPage(model.CurrentPage);

            model.DemotivatorList = page.DemotivatorList.ToList();

            model.DemotivatorSlideList = page.DemotivatorSlajdList.ToList();

            return View("Index", model);
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

            return RedirectToAction("Index");
        }
    }
}
