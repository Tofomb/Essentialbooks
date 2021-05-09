using Essentialbooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Essentialbooks.Controllers
{
    public class RealUserLoginController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RealUserLogin
        public ActionResult Index()
        {



            return View();
        }
        public ActionResult Create()
        {
            var Ru = db.RealUsers;
        
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Password,Email")] RealUser realUser)
        {
            if (ModelState.IsValid)
            {

                var x = realUser.Password;

                db.RealUsers.Add(realUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(realUser);
        }
    }
}