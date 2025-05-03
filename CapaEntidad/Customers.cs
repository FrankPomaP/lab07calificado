using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Customers
    {
        public int CustomerId { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public bool Active { get; set; } = true;

    }
}
