using MojeDemotywatory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MojeDemotywatory.Infrastructure
{
    public class OutOfRangeSlideAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is NullReferenceException)
            {
                var currentPage = filterContext.HttpContext.Request.QueryString["strona"];

                filterContext.Result = new ViewResult
                {
                    ViewName = "BrakStrony",
                    ViewData = new ViewDataDictionary<string>(currentPage)
                };


                filterContext.ExceptionHandled = true;
            }
        }
    }
}