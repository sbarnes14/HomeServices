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
    public class ApplianceController : Controller
    {
        // GET: Appliance
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ApplianceService(userId);
            var model = service.GetAppliances();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplianceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateApplianceService();

            if (service.CreateAppliance(model))
            {
                TempData["SaveResult"] = "Your appliance was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Appliance could not be added");

            return View(model);
        }

        private ApplianceService CreateApplianceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ApplianceService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateApplianceService();
            var model = svc.GetApplianceById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateApplianceService();
            var detail = service.GetApplianceById(id);
            var model =
                new ApplianceEdit
                {
                    ApplianceId = detail.ApplianceId,
                    ApplianceType = detail.ApplianceType,
                    Manufacturer = detail.Manufacturer,
                    ApplianceModel = detail.ApplianceModel
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ApplianceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ApplianceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateApplianceService();
            if (service.UpdateAppliance(model))
            {
                TempData["SaveResult"] = "your Appliance was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your appliance could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateApplianceService();
            var model = svc.GetApplianceById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAppliance(int id)
        {
            var service = CreateApplianceService();

            service.DeleteAppliance(id);

            TempData["SaveResult"] = "Your appliance was deleted";

            return RedirectToAction("Index");
        }
    }
}