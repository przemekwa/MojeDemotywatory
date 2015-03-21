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
    public class FajneController : Controller
    {
        //
        // GET: /Fajne/

        [AutoryzacjaUlubionych("Einstein")]
        public ActionResult Fajne()
        {
            var model = new PageModel();

            var baza = new Baza("baza2");

            List<Demotywator> listaMemow = new List<Demotywator>();

            foreach (var d in baza.Odczytaj())
            {
                listaMemow.Add(new Demotywator
                {
                    Url = d,
                    ImgUrl = d,
                });

            }

            model.DemotywatorList = listaMemow;

            return View("Fajne", model);
        }

       [AutoryzacjaUlubionych("Einstein")]
        public ActionResult Dodaj(string adres)
        {
            var model = new PageModel();

            var baza = new Baza("baza2");

            List<Demotywator> listaMemow = new List<Demotywator>();

            baza.Dodaj(adres);

            foreach (var d in baza.Odczytaj())
            {
                listaMemow.Add(new Demotywator
                {
                    Url = d,
                    ImgUrl = d,
                });
            }

            model.DemotywatorList = listaMemow;

            return View("Fajne", model);
        }

         [AutoryzacjaUlubionych("Einstein")]
        public ActionResult Usun(string adres)
        {
            var model = new PageModel();

            var baza = new Baza("baza2");

            baza.Usun(adres);

            List<Demotywator> listaMemow = new List<Demotywator>();

            foreach (var d in baza.Odczytaj())
            {
                listaMemow.Add(new Demotywator
                {
                    Url = d,
                    ImgUrl = d,
                  
                });
            }

            model.DemotywatorList = listaMemow;

            return View("Fajne", model);
        }


    }
}
