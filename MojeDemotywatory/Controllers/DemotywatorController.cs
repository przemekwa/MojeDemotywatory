using MojeDemotywatory.Infrastructure;
using MojeDemotywatory.Models;
using MojeDemotywatoryApi;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace MojeDemotywatory.Controllers
{
      public class DemotywatorController : Controller
    {

          public DemotivatorApi DemotivatorApi { get; set; } = new DemotivatorApi("http://demotywatory.pl/");

        private readonly ILogger log = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            this.log.Debug("Start aplikacji");

            var model = new PageModel
            {
                CurrentPage = 1
            };

            var page = this.DemotivatorApi.GetPage(model.CurrentPage);

            this.log.Debug($"Pobrano {page.DemotywatorList.Count} demotów.");

            model.DemotivatorList = page.DemotywatorList.ToList();

            model.DemotivatorSlajdList = page.DemotywatorSlajdList.ToList();

            return View(model);
        }
        
        [HandleError(ExceptionType=typeof(NullReferenceException), View="BrakStrony")]   
        public ActionResult Nastepna(int pageNumber)
        {
            var model = new PageModel
            {
                CurrentPage = pageNumber
            };

            var page = this.DemotivatorApi.GetPage(++model.CurrentPage);

            model.DemotivatorList = page.DemotywatorList.ToList();
            model.DemotivatorSlajdList = page.DemotywatorSlajdList.ToList();

            return View("Index", model);
        }

        [OutOfRangeSlide]
        public ActionResult Losowa(string strona)
        {
            var model = new PageModel();

            var losowa = new Random();

            model.CurrentPage = losowa.Next(model.CurrentPage, 10000);

            var page = this.DemotivatorApi.GetPage(model.CurrentPage);

            model.DemotivatorList = page.DemotywatorList.ToList();
            model.DemotivatorSlajdList = page.DemotywatorSlajdList.ToList();

            return View("Index", model);
        }
    }
}
