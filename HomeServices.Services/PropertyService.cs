using HomeServices.Data;
using HomeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Services
{
    public class PropertyService
    {
        private readonly Guid _userId;

        public PropertyService(Guid userid)
        {
            _userId = userid;
        }

        public bool CreateProperty(PropertyCreate model)
        {
            var entity =
                new Property()
                {
                    OwnerId = _userId,
                    SquareFootage = model.SquareFootage,
                    Yardsize = model.YardSize,
                    Address = model.Address
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Properties.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PropertyListItem> GetProperties()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Properties
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PropertyListItem
                                {
                                    PropertyId = e.PropertyId,
                                    SquareFootage = e.SquareFootage,
                                    YardSize = e.Yardsize,
                                    Address = e.Address
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
