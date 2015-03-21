using BazaLite;
using MojeDemotywatory.Infrastructure;
using MojeDemotywatory.Models;
using MojeDemotywatoryApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MojeDemotywatory.Controllers
{
    public class DemotywatorController : Controller
    {
        //
        // GET: /Demotywator/

        public ActionResult Index()
        {
            var demotywatoryApi = new DemotywatoryApi("http://demotywatory.pl/");

            var model = new PageModel();
            
            model.AktualnaStrona = 1;

            var page = demotywatoryApi.GetPage(model.AktualnaStrona);

            model.DemotywatorList = page.DemotywatorList.ToList();
            model.DemotywatorSlajdList = page.DemotywatorSlajdList.ToList();

            return View(model);
        }
        
        [HandleError(ExceptionType=typeof(NullReferenceException), View="BrakStrony")]   
        public ActionResult Nastepna(string strona)
        {
            if (string.IsNullOrEmpty(strona))
            {
                throw new ArgumentNullException("strona");
            }

            var demotywatoryApi = new DemotywatoryApi("http://demotywatory.pl/");
           
            var model = new PageModel();

            model.AktualnaStrona = Int32.Parse(strona);

            var page = demotywatoryApi.GetPage(++model.AktualnaStrona);

            model.DemotywatorList = page.DemotywatorList.ToList();
            model.DemotywatorSlajdList = page.DemotywatorSlajdList.ToList();

            return View("Index", model);
        }

        [WyjatekZakresu]
        public ActionResult Losowa(string strona)
        {
            var test = new DemotywatoryApi("http://demotywatory.pl/");

            var model = new PageModel();

            var losowa = new Random();

            model.AktualnaStrona = losowa.Next(model.AktualnaStrona, 10000);

            var page = test.GetPage(model.AktualnaStrona);

            model.DemotywatorList = page.DemotywatorList.ToList();
            model.DemotywatorSlajdList = page.DemotywatorSlajdList.ToList();

            return View("Index", model);
        }

      

    }
}
