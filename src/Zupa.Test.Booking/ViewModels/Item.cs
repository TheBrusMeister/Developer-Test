using System;

namespace Zupa.Test.Booking.ViewModels
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double NetPrice { get; set; }
        public double TaxRate { get; set; }
        public double GrossPrice { get; set; }
    }
}
