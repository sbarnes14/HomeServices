using System;
using System.Collections.Generic;
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
        public string MerchantName { get; set; }


        public ServiceType TypeService { get; set; }


        public int Rating { get; set; }
    }
}
