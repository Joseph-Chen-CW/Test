using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Filter
{
    public class ExceptionHandleAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            var result = new ViewResult()
            {
                ViewName = "Error",
            };
            result.ViewBag.Error = filterContext.Exception.Message;
            filterContext.Result = result;

            base.OnException(filterContext);
        }
    }
}