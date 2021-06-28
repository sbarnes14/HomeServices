using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Data
{
   public class Property
    {
        [Key]
        public int PropertyId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }


        [Required]
        public int SquareFootage { get; set; }

        [Required]
        public int Yardsize { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
