using HomeServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        
        [ForeignKey(nameof(PropertyId))]
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }


    }
}
