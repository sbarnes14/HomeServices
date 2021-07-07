using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Data
{
    public enum ServiceStatus { Open, InProgress, Completed }
    public class WorkOrder
    {
        [Key]
        public int WorkOrderId { get; set; }
        
        [Required]
        public int PropertyId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }


        public ServiceType TypeService { get; set; }
        public ServiceStatus ServiceStatus { get; set; }

    }
}
