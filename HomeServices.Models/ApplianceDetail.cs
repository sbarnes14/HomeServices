using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class ApplianceDetail
    {
        public int ApplianceId { get; set; }
        public string ApplianceType { get; set; }
        public string  Manufacturer { get; set; }
        public string ApplianceModel { get; set; }
    }
}
