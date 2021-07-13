using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class PropertyListItem
    {
        public int PropertyId { get; set; }
        [Display(Name ="Square Footage")]
        public int SquareFootage { get; set; }
        [Display(Name ="Yard Size")]
        public int YardSize { get; set; }
        public string Address { get; set; }
    }
}
