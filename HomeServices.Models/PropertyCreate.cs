using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class PropertyCreate
    {
        [Required]
        [Display(Name ="Square Footage")]
        public int SquareFootage { get; set; }

        [Required]
        [Display(Name ="Yard Size")]
        public int YardSize { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
