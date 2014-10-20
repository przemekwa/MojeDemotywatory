﻿using MojeDemotywatory.Models;
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

            model.ListaDemotow = test.PobierzDemotywatoryZeStron(4);

            return View(model);
        }

    }
}