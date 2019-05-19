using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zupa.Test.Booking.Models
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double NetPrice { get; set; }
        public double TaxRate { get; set; }
        public double GrossPrice { get; set; }
        public int Quantity { get; set; }
    }
}
