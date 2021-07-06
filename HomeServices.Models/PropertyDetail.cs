using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
   public class PropertyDetail
    {
        public int PropertyId { get; set; }
        public int SquareFootage { get; set; }
        public int YardSize { get; set; }
        public string Address { get; set; }
        public string ApplianceType { get; set; }
        public string Manufacturer { get; set; }
        public string ApplianceModel { get; set; }

    }
}
