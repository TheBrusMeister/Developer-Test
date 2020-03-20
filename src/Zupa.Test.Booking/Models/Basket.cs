using System.Collections.Generic;
using System.Linq;

namespace Zupa.Test.Booking.Models
{
    public class Basket
    {
        public IEnumerable<BasketItem> Items { get; set; } = new List<BasketItem>();
        public double DiscountedTotal { get; set; }
        public double Total { get; set; }

        public double GetTotal(List<BasketItem> items)
        {

            if (items.Any()){
                var total = 0.00;

                items.ForEach(x =>
                {
                    if (x.Quantity > 1)
                    {
                        total += x.GrossPrice * x.Quantity;
                    }

                    total += x.GrossPrice;
                    Total = total;
                });
            }
        

            return Total;
        }
    }
}
