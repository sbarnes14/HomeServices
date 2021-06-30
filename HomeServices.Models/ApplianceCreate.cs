using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class ApplianceCreate
    {
        [Required]
        public string ApplianceType { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string ApplianceModel { get; set; }

    }
}
