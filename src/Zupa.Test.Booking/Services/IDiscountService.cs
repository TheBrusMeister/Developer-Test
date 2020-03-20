using Zupa.Test.Booking.Models;
using Zupa.Test.Booking.ViewModels;

namespace Zupa.Test.Booking.Services
{
    public interface IDiscountService
    {
        void ApplyDiscount(ViewModels.Basket basket, DiscountItem discountItem);
    }
}
