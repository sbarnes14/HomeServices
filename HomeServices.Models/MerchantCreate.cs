using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public enum ServiceType
    {
  HVAC,
  Plumbing,
  Carpentry,
  Electrical,
  Appliance_Repair,
  Cleaning,
  Exterminator,
  Landscaping,
  Painting,
  Misc
    }
    public class MerchantCreate
    {
        [Display(Name ="Merchant Name")]
        public string MerchantName { get; set; }

        [Display(Name ="Service Type")]
        public ServiceType TypeService { get; set; }


        public int Rating { get; set; }
    }
}
