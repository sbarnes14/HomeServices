﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class MerchantDetail
    {
        public int MerchantId { get; set; }

        public string MerchantName { get; set; }


        public ServiceType TypeService { get; set; }


        public int Rating { get; set; }
    }
}
