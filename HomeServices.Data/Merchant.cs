using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Data
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
    public class Merchant
    {
        [Key]
        public int MerchantId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }


        [Required]
        public string MerchantName { get; set; }

        
        public ServiceType TypeService { get; set; }


        public int Rating { get; set; }
    }
}
