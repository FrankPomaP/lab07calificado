﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public bool Active { get; set; } = true;
    }
}
