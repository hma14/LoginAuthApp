using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationApp.Controllers
{
    public class CustomHandleErrorAttributs : HandleErrorAttribute
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            // if the request is AJAX return JSON else view.
            if (IsAjax(filterContext))
            {
                //Because its a exception raised after ajax invocation
                //Lets return Json
                filterContext.Result = new JsonResult()
                {
                    Data = filterContext.Exception.Message,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                //Normal Exception
                //So let it handle by its default ways.
                base.OnException(filterContext);

            }


            // Write error logging code here if you wish.
            string ErrorData = JObject.FromObject(
                new {
                    ExceptionMessage = filterContext.Exception.Message,
                    Controller = filterContext.RouteData.Values["Controller"],
                    Action = filterContext.RouteData.Values["Action"],
                    TimeStamp = DateTime.Now
        }).ToString();

            LogEventInfo logInfo = new LogEventInfo(LogLevel.Error, ConfigurationManager.AppSettings["EventLogSource"], ErrorData);
            logger.Error(logInfo);

            //if want to get different of the request
            //var currentController = (string)filterContext.RouteData.Values["controller"];
            //var currentActionName = (string)filterContext.RouteData.Values["action"];
        }

    }
}