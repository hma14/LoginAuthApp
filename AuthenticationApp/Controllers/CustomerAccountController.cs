using AuthenticationApp.Controllers;
using AuthenticationApp.Models;
using AuthenticationApp.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationApp.Controllers
{
    public class CustomerAccountController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        // POST: Registration
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [CustomHandleErrorAttributs]
        public ActionResult Registration(CustomerAccountViewModel customer, string userId)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
#if true
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<CustomerAccountViewModel, CustomerAccount>();
                });
                IMapper mapper = config.CreateMapper(); 
                var entity = mapper.Map<CustomerAccountViewModel, CustomerAccount>(customer);
#else
                var entity = new CustomerAccount
                {

                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Phone = customer.Phone
                };
#endif
                using (var context = new AppDbContext())
                {                  
                    context.Set<CustomerAccount>().Add(entity);
                    entity.EmailAddress = context.AspNetUsers.Where(x => x.Id.ToString() == userId).Select(y => y.Email).FirstOrDefault();
                    context.SaveChanges();
                    
                }


                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}