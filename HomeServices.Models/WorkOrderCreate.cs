using HomeServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class WorkOrderCreate
    {
        [Required]
        public int PropertyId { get; set; }

        [Required]
        [Display(Name ="Service Type")]
        public ServiceType TypeService { get; set; }

        [Required]
        public ServiceStatus ServiceStatus { get; set; }
    }
}
