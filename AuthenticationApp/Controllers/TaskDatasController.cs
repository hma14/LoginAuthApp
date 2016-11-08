using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuthenticationApp.Models;
using AuthenticationApp.ViewModels;
using AutoMapper;
using AuthenticationApp.Common;

namespace AuthenticationApp.Controllers
{
    public class TaskDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TaskDatas
        public async Task<ActionResult> Index()
        {
            return View(await db.TaskDatas.ToListAsync());
        }

        // GET: TaskDatas/Details/5
        public async Task<ActionResult> Details(string userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskData taskData = await db.TaskDatas.FindAsync(userId);
            if (taskData == null)
            {
                return HttpNotFound();
            }
            return View(taskData);
        }

        // GET: TaskDatas/Create
        public ActionResult Create()
        {
            TaskDataViewModel model = new TaskDataViewModel();
            return View(model);
        }

        // POST: TaskDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( TaskDataViewModel model)
        {
            if (ModelState.IsValid)
            {
                TaskData taskData = new TaskData();
                
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<TaskDataViewModel, TaskData>();
                });

                var mapper = config.CreateMapper();
                taskData = mapper.Map<TaskData>(model);

                taskData.TaskId = Guid.NewGuid();
                taskData.UserId = db.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id;
                taskData.CustomerId = taskData.UserType == USER_TYPE.Customer ? taskData.UserId : null;
                taskData.VenderId = taskData.UserType == USER_TYPE.Vendor ? taskData.UserId : null;
                taskData.StateId = States.PendingRFQ;
                taskData.StateName = Enum.GetName(typeof(States), States.PendingRFQ);
                taskData.CreateTC = taskData.UpdateTC = DateTime.UtcNow;
                taskData.UpdateBy = User.Identity.Name;

                db.TaskDatas.Add(taskData);
                await db.SaveChangesAsync();

                //TempData["Status"] = taskData.StateName;
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }


        // GET: TaskDatas/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskData taskData = await db.TaskDatas.FindAsync(id);
            if (taskData == null)
            {
                return HttpNotFound();
            }
            return View(taskData);
        }

        // POST: TaskDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TaskId,UserId,UserType,CustomerId,VenderId,StateId,StateName,PartNumberRevision,Material,Process,QuantityBreak,LeadTime,FileType,CreateTC,UpdateTC")] TaskData taskData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskData).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(taskData);
        }

        // GET: TaskDatas/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskData taskData = await db.TaskDatas.FindAsync(id);
            if (taskData == null)
            {
                return HttpNotFound();
            }
            return View(taskData);
        }

        // POST: TaskDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            TaskData taskData = await db.TaskDatas.FindAsync(id);
            db.TaskDatas.Remove(taskData);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
