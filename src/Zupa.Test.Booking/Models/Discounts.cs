using System.Collections.Generic;

namespace Zupa.Test.Booking.Models
{
    public class Discounts
    {
        public IEnumerable<DiscountItem> DiscountList { get; set; } = new List<DiscountItem>();
    }
}
