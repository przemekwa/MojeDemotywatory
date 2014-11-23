using MojeDemotywatory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MojeDemotywatory.Infrastructure
{
    public class WyjatekZakresu : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is NullReferenceException)
            {
                var AktualnaStrona = filterContext.HttpContext.Request.QueryString["strona"];

                var model = new Demotywatory();

                filterContext.Result = new ViewResult
                {
                    ViewName = "BrakStrony",
                    ViewData = new ViewDataDictionary<string>(AktualnaStrona)
                };

                filterContext.ExceptionHandled = true;
            }
        }
    }
}