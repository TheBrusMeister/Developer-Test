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

        public static Models.BasketItem ToBasketItemModel(this BasketItem basketItem)
        {
            return new Models.BasketItem
            {
                Id = basketItem.Id,
                Name = basketItem.Name,
                GrossPrice = basketItem.GrossPrice,
                NetPrice = basketItem.NetPrice,
                TaxRate = basketItem.TaxRate,
                Quantity = basketItem.Quantity
            };
        }

        public static IEnumerable<Models.BasketItem> ToBasketItemModels(this IEnumerable<BasketItem> basketItems)
        {
            return basketItems.Select(
                item => new Models.BasketItem
                {
                    Id = item.Id,
                    Name = item.Name,
                    GrossPrice = item.GrossPrice,
                    NetPrice = item.NetPrice,
                    TaxRate = item.TaxRate,
                    Quantity = item.Quantity
                });
        }

        public static IEnumerable<BasketItem> ToBasketItemViewModels(this IEnumerable<Models.BasketItem> basketItems)
        {
            return basketItems.Select(
                item => new BasketItem
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
