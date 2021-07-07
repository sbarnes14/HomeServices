using HomeServices.Data;
using HomeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Services
{
    public class WorkOrderService
    {
        private readonly Guid _userId;

        public WorkOrderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWorkOrder(WorkOrderCreate model)
        {
            var entity =
                new WorkOrder()
                {
                    OwnerId = _userId,
                    PropertyId = model.PropertyId,
                    TypeService = (Data.ServiceType)model.TypeService,
                    ServiceStatus = model.ServiceStatus
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.WorkOrders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkOrderListItem> GetWorkOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .WorkOrders
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new WorkOrderListItem
                                {
                                    WorkOrderId = e.WorkOrderId,
                                    PropertyId = e.PropertyId,
                                    TypeService = (Models.ServiceType)e.TypeService,
                                    ServiceStatus = e.ServiceStatus
                                }
                        );
                return query.ToArray();
            }
        }

        public WorkOrderDetail GetWorkOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkOrders
                        .Single(e => e.WorkOrderId == id && e.OwnerId == _userId);
                return
                    new WorkOrderDetail
                    {
                        WordOrderId = entity.WorkOrderId,
                        PropertyId = entity.PropertyId,
                        TypeService = (Models.ServiceType)entity.TypeService,
                        ServiceStatus = entity.ServiceStatus
                    };
            }
        }

        public bool UpdateWorkOrder(WorkOrderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkOrders
                        .Single(e => e.WorkOrderId == model.WorkOrderId && e.OwnerId == _userId);

                entity.WorkOrderId = model.WorkOrderId;
                entity.PropertyId = model.PropertyId;
                entity.TypeService = (Data.ServiceType)model.TypeService;
                entity.ServiceStatus = model.ServiceStatus;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWorkOrder(int workOrderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkOrders
                        .Single(e => e.WorkOrderId == workOrderId && e.OwnerId == _userId);

                ctx.WorkOrders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
