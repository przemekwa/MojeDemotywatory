
using MojeDemotywatoryApi.Interface;
using MojeDemotywatoryApi.Models;
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

        public DemotivatorController(IFavoritesDemotivatorApi favoritesDemotivatorApi, IDemotivatorApi demotivatorApi )
        {
            this.favoritesDemotivatorApi = favoritesDemotivatorApi;
            this.demotivatorApi = demotivatorApi;
        }

        public ActionResult Index()
        {
            var model = new PageModel
            {
                CurrentPage = 1,
                FavoriteCount = favoritesDemotivatorApi.Get().Count()
            };

            var page = this.demotivatorApi.GetPage(model.CurrentPage);

            model.DemotivatorList = page.DemotivatorCollection.ToList();

            model.DemotivatorSlideList = page.DemotivatorSlideCollection.ToList();

            return View(model);
        }

        [HandleError(ExceptionType = typeof(NullReferenceException), View = "PageNotExist")]
        public ActionResult GetNextPage(int pageNumber = 1)
        {
            var page = this.GetPage(++pageNumber);

            var model = new PageModel
            {
                CurrentPage = pageNumber,
                DemotivatorList = page.DemotivatorCollection.ToList(),
                DemotivatorSlideList = page.DemotivatorSlideCollection.ToList()
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

            try
            {
                var page = this.GetPage(model.CurrentPage);

                model.DemotivatorList = page.DemotivatorCollection.ToList();

                model.DemotivatorSlideList = page.DemotivatorSlideCollection.ToList();
            }
            catch (Exception e)
            {
                throw new OutOfRangeException(e);
            }
            
            return View("Index", model);
        }


        private Page GetPage(int currentPage)
        {
            try
            {
                return this.demotivatorApi.GetPage(currentPage);
            }
            catch (Exception e)
            {
                throw new OutOfRangeException(e);
            }
        }

    }
}
