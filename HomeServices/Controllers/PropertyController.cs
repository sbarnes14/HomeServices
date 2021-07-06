using HomeServices.Data;
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
            if (!ModelState.IsValid) return View(model);

            var service = CreatePropertyService();

            if (service.CreateProperty(model))
            {
                TempData["SaveResult"] = "Your Property was added successfully";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Property could not be added");

            return View(model);
        }

        private PropertyService CreatePropertyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PropertyService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePropertyService();
            var model = svc.GetPropertyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePropertyService();
            var detail = service.GetPropertyById(id);
            var model =
                new PropertyEdit
                {
                    PropertyId = detail.PropertyId,
                    SquareFootage = detail.SquareFootage,
                    YardSize = detail.YardSize,
                    Address = detail.Address
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PropertyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.PropertyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePropertyService();

            if (service.UpdateProperty(model))
            {
                TempData["SaveResult"] = "your property was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your property could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePropertyService();
            ;
            var model = svc.GetPropertyById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProperty(int id)
        {
            var service = CreatePropertyService();

            service.DeleteProperty(id);

            TempData["SaveResult"] = "Your Property was deleted";

            return RedirectToAction("Index");
        }
    }
}