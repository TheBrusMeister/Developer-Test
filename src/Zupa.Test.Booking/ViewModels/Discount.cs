using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.ViewModels
{
    public class Discount: DiscountItem
    {
        public DiscountItem ToDiscountItem()
        {
            return new DiscountItem()
            {
                Code = Code,
                Amount = Amount
            };
        }
    }

}
