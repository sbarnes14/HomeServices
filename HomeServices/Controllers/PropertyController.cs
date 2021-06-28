using HomeServices.Models;
using HomeServices.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeServices.Controllers
{
    [Authorize]
    public class PropertyController : Controller
    {
        // GET: Property
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyService(userId);
            var model = service.GetProperties();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyService(userId);

            service.CreateProperty(model);

            return RedirectToAction("Index");
        }
    }
}