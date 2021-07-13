using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class ApplianceDetail
    {
        public int ApplianceId { get; set; }

        [Display(Name="Appliance Type")]
        public string ApplianceType { get; set; }
        public string  Manufacturer { get; set; }

        [Display(Name ="Appliance Model")]
        public string ApplianceModel { get; set; }
    }
}
