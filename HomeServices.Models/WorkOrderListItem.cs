using HomeServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class WorkOrderListItem
    {
        public int WorkOrderId { get; set; }
        public int PropertyId { get; set; }
        public ServiceType TypeService { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
    }
}
