using System;

namespace Zupa.Test.Booking.ViewModels
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double NetPrice { get; set; }
        public double TaxRate { get; set; }
        public double TaxValue { get; set; }
        public double GrossPrice { get; set; }
    }
}
