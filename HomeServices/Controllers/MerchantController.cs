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
    public class MerchantController : Controller
    {
        // GET: Merchant
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MerchantService(userId);
            var model = service.GetMerchants();

            return View(model);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MerchantCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMerchantService();

            if (service.CreateMerchant(model))
            {
                TempData["SaveResult"] = "Merchant Created Successfully";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Merchant could not be added");

            return View(model);
        }

        private MerchantService CreateMerchantService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MerchantService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMerchantService();
            var model = svc.GetMerchantById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMerchantService();
            var detail = service.GetMerchantById(id);
            var model =
                new MerchantEdit
                {
                    MerchantId = detail.MerchantId,
                    TypeService = detail.TypeService,
                    MerchantName = detail.MerchantName,
                    Rating = detail.Rating
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, MerchantEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if (model.MerchantId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMerchantService();

            if (service.UpdateMerchant(model))
            {
                TempData["SaveResult"] = "Merchant Was Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Merchant could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateMerchantService();

            var model = service.GetMerchantById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMerchant(int id)
        {
            var service = CreateMerchantService();
            service.DeleteMerchant(id);
            TempData["SaveResult"] = "Merchant was deleted";
            return RedirectToAction("Index");
        }
    }
}