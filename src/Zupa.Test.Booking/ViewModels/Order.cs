using System;
using System.Collections.Generic;

namespace Zupa.Test.Booking.ViewModels
{
    public class Order
    {
        public Guid ID { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public double NetTotal { get; set; }
        public double TaxTotal { get; set; }
        public double GrossTotal { get; set; }
        public double DiscountedTotal { get; set; }
    }
}
