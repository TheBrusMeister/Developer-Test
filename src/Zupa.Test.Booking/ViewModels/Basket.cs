using System.Collections.Generic;

namespace Zupa.Test.Booking.ViewModels
{
    public class Basket
    {
        public IEnumerable<BasketItem> Items { get; set; }

        public double Total { get; set; }

        public void ApplyDiscount(double amount)
        {
            var subtractionMultiplier = amount / 100;
            var subtractionAmount = Total * subtractionMultiplier;

            Total -= subtractionAmount;
        }
    }
}
