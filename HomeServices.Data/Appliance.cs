using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Data
{
    public class Appliance
    {
        [Key]
        public int ApplianceId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey("Property")]
        [Required]
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }

        [Required]
        public string ApplianceType { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string ApplianceModel { get; set; }

    }
}
