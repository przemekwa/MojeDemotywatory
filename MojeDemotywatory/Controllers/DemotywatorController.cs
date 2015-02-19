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
            var test = new DemotywatoryApi("http://demotywatory.pl/");

            var model = new Demotywatory();
            
            model.AktualnaStrona = 1;

            model.ListaDemotow = test.PobierzZeStron(model.AktualnaStrona).ToList();

            return View(model);
        }
        //[WyjatekZakresu]
        [HandleError(ExceptionType=typeof(NullReferenceException), View="BrakStrony")]   
        public ActionResult Nastepna(string strona)
        {
         
                       
            if (string.IsNullOrEmpty(strona))
            {
                throw new ArgumentNullException("strona");
            }

            var test = new DemotywatoryApi("http://demotywatory.pl/");

           
            var model = new Demotywatory();

            model.AktualnaStrona = Int32.Parse(strona);

            model.ListaDemotow = test.PobierzZeStrony(++model.AktualnaStrona).ToList();

            return View("Index", model);
        }

        [WyjatekZakresu]
        public ActionResult Losowa(string strona)
        {
            var test = new DemotywatoryApi("http://demotywatory.pl/");

            var model = new Demotywatory();

            var losowa = new Random();

            model.AktualnaStrona = losowa.Next(model.AktualnaStrona, 10000);

            model.ListaDemotow = test.PobierzZeStrony(model.AktualnaStrona).ToList();

            return View("Index", model);
        }

      

    }
}
