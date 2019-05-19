using System.Collections.Generic;
using System.Linq;

namespace Zupa.Test.Booking.ViewModels
{
    public static class BasketItemExtensionMethods
    {
        public static IEnumerable<Models.OrderItem> ToOrderItemModels(this IEnumerable<BasketItem> basketItems)
        {
            return basketItems.Select(
                item => new Models.OrderItem
                {
                    Id = item.Id,
                    Name = item.Name,
                    GrossPrice = item.GrossPrice,
                    NetPrice = item.NetPrice,
                    TaxRate = item.TaxRate,
                    Quantity = item.Quantity
                });
        }
    }
}
