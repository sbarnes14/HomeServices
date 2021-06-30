using HomeServices.Data;
using HomeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Services
{
    public class ApplianceService
    {
        private readonly Guid _userId;

        public ApplianceService(Guid userid)
        {
            _userId = userid;
        }

        public bool CreateAppliance(ApplianceCreate model)
        {
            var entity =
                new Appliance()
                {
                    OwnerId = _userId,
                    ApplianceModel = model.ApplianceModel,
                    Manufacturer = model.Manufacturer,
                    ApplianceType = model.ApplianceType
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Appliances.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ApplianceListItem> GetAppliances()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Appliances
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ApplianceListItem
                                {
                                    ApplianceId = e.ApplianceId,
                                    ApplianceType = e.ApplianceType,
                                    Manufacturer = e.Manufacturer,
                                    ApplianceModel = e.ApplianceModel
                                }
                        );
                return query.ToArray();
            }
        }

        public ApplianceDetail GetApplianceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appliances
                        .Single(e => e.ApplianceId == id && e.OwnerId == _userId);
                return
                        new ApplianceDetail
                        {
                            ApplianceId = entity.ApplianceId,
                            ApplianceType = entity.ApplianceType,
                            Manufacturer = entity.Manufacturer,
                            ApplianceModel = entity.ApplianceModel
                        };
            }
        }

        public bool UpdateAppliance(ApplianceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appliances
                        .Single(e => e.ApplianceId == model.ApplianceId && e.OwnerId == _userId);

                entity.ApplianceType = model.ApplianceType;
                entity.Manufacturer = model.Manufacturer;
                entity.ApplianceModel = model.ApplianceModel;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAppliance(int applianceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appliances
                        .Single(e => e.ApplianceId == applianceId && e.OwnerId == _userId);
                ctx.Appliances.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
