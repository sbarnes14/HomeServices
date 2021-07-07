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
    public class WorkOrderController : Controller
    {
        // GET: WorkOrder
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkOrderService(userId);
            var model = service.GetWorkOrders();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkOrderCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            WorkOrderService service = CreateWorkOrderService();

            if (service.CreateWorkOrder(model))
            {
                TempData["SaveResult"] = "Work Order created successfully";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Work Order could not be added");

            return View(model);
        }

        private WorkOrderService CreateWorkOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkOrderService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var service = CreateWorkOrderService();
            var detail = service.GetWorkOrderById(id);
            var model =
                new WorkOrderEdit
                {
                    WorkOrderId = detail.WordOrderId,
                    PropertyId = detail.PropertyId,
                    TypeService = detail.TypeService,
                    ServiceStatus = detail.ServiceStatus
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkOrderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WorkOrderId != id)
            {
                ModelState.AddModelError("", "id mismatch");
                return View(model);
            }

            var service = CreateWorkOrderService();

            if (service.UpdateWorkOrder(model))
            {
                TempData["Saveresult"] = "your work order was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Work order could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateWorkOrderService();
            var model = service.GetWorkOrderById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWorkOrder(int id)
        {
            var service = CreateWorkOrderService();
            service.DeleteWorkOrder(id);
            TempData["SaveResult"] = "Work order has been deleted";
            return RedirectToAction("Index");
        }
    }
}