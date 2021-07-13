using HomeServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class WorkOrderEdit
    {
        [Display(Name ="Work OrderId")]
        public int WorkOrderId { get; set; }
        public int PropertyId { get; set; }
        [Display(Name ="Service Type")]
        public ServiceType TypeService { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
    }
}
