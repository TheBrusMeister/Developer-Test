using System.Collections.Generic;

namespace Zupa.Test.Booking.ViewModels
{
    public class Basket
    {
        public IEnumerable<BasketItem> Items { get; set; }

        public double Total { get; set; }

        public double DiscountedTotal { get; set; }

        public string SuccessMessage { get; set; }

        public string FailureMessage { get; set; }
    }
}
