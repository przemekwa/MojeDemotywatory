
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
        public DemotivatorApi DemotivatorApi { get; set; } = new DemotivatorApi("http://demotywatory.pl/");

        public FavoritesDemotivatorDbApi FavoritesDemotivatorDbApi { get; private set; } = new FavoritesDemotivatorDbApi();

        private readonly ILogger log = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            this.log.Debug("Start aplikacji");

            var model = new PageModel
            {
                CurrentPage = 1,
                FavoriteCount = FavoritesDemotivatorDbApi.GetFavoritesDemotivator().Count()
            };

            var page = this.DemotivatorApi.GetPage(model.CurrentPage);

            this.log.Debug($"Pobrano {page.DemotivatorList.Count} demotów.");

            model.DemotivatorList = page.DemotivatorList.ToList();

            model.DemotivatorSlideList = page.DemotivatorSlajdList.ToList();

            return View(model);
        }

        [HandleError(ExceptionType = typeof(NullReferenceException), View = "PageNotExist")]
        public ActionResult GetNextPage(int pageNumber)
        {
            var model = new PageModel
            {
                CurrentPage = pageNumber
            };

            var page = this.DemotivatorApi.GetPage(++model.CurrentPage);

            model.DemotivatorList = page.DemotivatorList.ToList();

            model.DemotivatorSlideList = page.DemotivatorSlajdList.ToList();

            return View("Index", model);
        }

        [OutOfRangeSlide]
        public ActionResult GetRandomPage()
        {
            var model = new PageModel();

            var random = new Random();

            model.CurrentPage = random.Next(model.CurrentPage, 10000);

            var page = this.DemotivatorApi.GetPage(model.CurrentPage);

            model.DemotivatorList = page.DemotivatorList.ToList();

            model.DemotivatorSlideList = page.DemotivatorSlajdList.ToList();

            return View("Index", model);
        }

        public ActionResult SaveFavorite(string url, string imgUrl)
        {
            this.FavoritesDemotivatorDbApi.Add(new Favorites
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
