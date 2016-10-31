using AuthenticationApp.Controllers;
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
    [CustomHandleErrorAttributs]
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {          
            Logger.Info(SetLogData("Index()"));
            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            Logger.Info(SetLogData("Your application description page."));

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            Logger.Info(SetLogData("Your contact page."));

            return View();
        }

        
    }
}