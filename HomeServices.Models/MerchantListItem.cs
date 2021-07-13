using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class MerchantListItem
    {
        public int MerchantId { get; set; }

        [Display(Name ="Merchant Name")]
        public string MerchantName { get; set; }

        [Display(Name ="Service Type")]
        public ServiceType TypeService { get; set; }
        public int Rating { get; set; }

    }
}
