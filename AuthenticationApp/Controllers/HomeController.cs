using AuthenticationApp.Common;
using AuthenticationApp.Controllers;
using AuthenticationApp.Models;
using AuthenticationApp.ViewModels;
using AutoMapper;
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
        [AllowAnonymous]
        public ActionResult Index()
        {          
            Logger.Info(SetLogData("Index()"));

            if (User.Identity.IsAuthenticated)
            {
                // retrieve task data from TaskDatas table
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var userEntity = db.Users.Where(u => u.Email == User.Identity.Name);
                    if (userEntity != null)
                    {
                        var taskEntities = db.TaskDatas.Where(x => x.UserId == userEntity.FirstOrDefault().Id);
                        if (taskEntities.Any())
                        {
                            var taskEntity = taskEntities.OrderByDescending(y => y.UpdateTC).FirstOrDefault();
                            if (taskEntity.UserType == Common.USER_TYPE.Customer)
                            {
                                TempData["Status"] = taskEntity.StateName;
                            }
                            else if (taskEntity.UserType == Common.USER_TYPE.Adimin)
                            {
                                List<TaskData> tasks = db.TaskDatas.Where(x => x.StateId == States.PendingRFQ).ToList();
                                IList<TaskDataViewModel> entities = new List<TaskDataViewModel>();
                                var config = new MapperConfiguration(cfg => {
                                    cfg.CreateMap<TaskData, TaskDataViewModel>();
                                });

                                var mapper = config.CreateMapper();
                                foreach (var task in tasks)
                                {
                                    var ent = mapper.Map<TaskDataViewModel>(task);
                                    entities.Add(ent);
                                }
                                return PartialView("_AdminLanding", entities);
                            }
                        }                        
                    }
                }               
            }
            return View();
        }
     
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            Logger.Info(SetLogData("Your application description page."));

            return View();
        }
     
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            Logger.Info(SetLogData("Your contact page."));

            return View();
        }

        
    }
}