﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class PropertyListItem
    {
        public int PropertyId { get; set; }
        public int SquareFootage { get; set; }
        public int YardSize { get; set; }
        public string Address { get; set; }
    }
}
