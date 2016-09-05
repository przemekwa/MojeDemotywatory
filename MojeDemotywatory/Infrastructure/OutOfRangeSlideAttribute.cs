
namespace MojeDemotywatory.Infrastructure
{
    using System;
    using System.Web.Mvc;

    public class OutOfRangeSlideAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is OutOfRangeException)
            {
                var currentPage = filterContext.HttpContext.Request.QueryString["pageNumber"];

                filterContext.Result = new ViewResult
                {
                    ViewName = "PageNotExist",
                    ViewData = new ViewDataDictionary<string>(currentPage)
                };

                filterContext.ExceptionHandled = true;
            }
        }
    }
}