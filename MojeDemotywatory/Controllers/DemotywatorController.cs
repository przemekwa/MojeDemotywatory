using BazaLite;
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
            var test = new FabrykaDemotywatorow("http://demotywatory.pl/");

            var model = new Demotywatory();
            
            model.AktualnaStrona = 1;

            model.ListaDemotow = test.PobierzDemotywatoryZeStron(model.AktualnaStrona);

            return View(model);
        }

        public ActionResult Dodaj(string adres)
        {
            var model = new Demotywatory();

            var baza = new Baza("baza2");

            baza.Dodaj(adres);

            List<Mem> listaMemow = new List<Mem>();

            foreach (var d in baza.Odczytaj())
            {
                listaMemow.Add(new Mem
                {
                    AdresUrl = d,
                    ObrazekUrl = d,
                    czySlajdy = false,
                });
            }

            model.ListaDemotow = listaMemow;

            return View("Index", model);
        }

        public ActionResult Nastepna(string strona)
        {
            var test = new FabrykaDemotywatorow("http://demotywatory.pl/");

            var model = new Demotywatory();

            model.AktualnaStrona = Int32.Parse(strona);

            model.ListaDemotow = test.PobierzDemotywatoryZeStrony(++model.AktualnaStrona);

            return View("Index", model);
        }

        public ActionResult Losowa(string strona)
        {
            var test = new FabrykaDemotywatorow("http://demotywatory.pl/");

            var model = new Demotywatory();

            var losowa = new Random();

            model.AktualnaStrona = losowa.Next(model.AktualnaStrona, 10000);

            model.ListaDemotow = test.PobierzDemotywatoryZeStrony(model.AktualnaStrona);

            return View("Index", model);
        }

        public ActionResult Ulubione()
        {
            var model = new Demotywatory();

            var baza = new Baza("baza2");

            List<Mem> listaMemow = new List<Mem>();

            foreach (var d in baza.Odczytaj())
            {
                listaMemow.Add(new Mem{
                    AdresUrl = d,
                    ObrazekUrl = d,
                    czySlajdy = false,
                });
            }

            model.ListaDemotow = listaMemow;

            return View("Index", model);
        }

    }
}
