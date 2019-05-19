using System;

namespace Zupa.Test.Booking.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double NetPrice { get; set; }
        public double TaxRate { get; set; }
        public double GrossPrice { get; set; }
        public int Quantity { get; set; }
    }
}
