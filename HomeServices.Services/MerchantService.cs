using HomeServices.Data;
using HomeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeServices.Data.Merchant;

namespace HomeServices.Services
{
    public class MerchantService
    {
        private readonly Guid _userId;

        public MerchantService (Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMerchant(MerchantCreate model)
        {
            var entity =
                new Merchant()
                {
                    OwnerId = _userId,
                    MerchantName = model.MerchantName,
                    TypeService = (Data.ServiceType)model.TypeService,
                    Rating = model.Rating
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Merchants.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MerchantListItem> GetMerchants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Merchants
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MerchantListItem
                                {
                                    MerchantName = e.MerchantName,
                                    TypeService = (Models.ServiceType)e.TypeService,
                                    Rating = e.Rating
                                }
                        );
                return query.ToArray();
            }
        }

        public MerchantDetail GetMerchantById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Merchants
                        .Single(e => e.MerchantId == id && e.OwnerId == _userId);
                return
                    new MerchantDetail
                    {
                        MerchantId = entity.MerchantId,
                        TypeService = (Models.ServiceType)entity.TypeService,
                        MerchantName = entity.MerchantName,
                        Rating = entity.Rating
                    };
            }
        }

        public bool UpdateMerchant(MerchantEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Merchants
                        .Single(e => e.MerchantId == model.MerchantId && e.OwnerId == _userId);

                entity.MerchantId = model.MerchantId;
                entity.TypeService = (Data.ServiceType)model.TypeService;
                entity.MerchantName = model.MerchantName;
                entity.Rating = model.Rating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMerchant(int merchantId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Merchants
                        .Single(e => e.MerchantId == merchantId && e.OwnerId == _userId);
                ctx.Merchants.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
