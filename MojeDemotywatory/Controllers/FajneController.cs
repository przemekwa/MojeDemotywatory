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
    public class FajneController : Controller
    {
        //
        // GET: /Fajne/

        public ActionResult Fajne()
        {
            var model = new Demotywatory();

            var baza = new Baza("baza2");

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

            return View("Fajne", model);
        }

        public ActionResult Dodaj(string adres)
        {
            var model = new Demotywatory();

            var baza = new Baza("baza2");

            List<Mem> listaMemow = new List<Mem>();

            baza.Dodaj(adres);

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

            return View("Fajne", model);
        }

        public ActionResult Usun(string adres)
        {
            var model = new Demotywatory();

            var baza = new Baza("baza2");

            baza.Usun(adres);

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

            return View("Fajne", model);
        }


    }
}
