using System;
using System.Collections.Generic;
using System.Linq;

namespace Zupa.Test.Booking.ViewModels
{
    public static class BasketExtensionMethods
    {
        public static Models.Order ToOrderModel(this Basket basket)
        {
            return new Models.Order
            {
                ID = Guid.NewGuid(),
                GrossTotal = basket.Items.Sum(item => item.GrossPrice),
                NetTotal = basket.Items.Sum(item => item.NetPrice),
                TaxTotal = basket.Items.Sum(item => item.NetPrice * item.TaxRate),
                Items = basket.Items.ToOrderItemModels(),
                DiscountedTotal = basket.DiscountedTotal
            };
        }

        public static Basket ToBasketViewModel(this Models.Basket basket)
        {
            return new Basket
            {
                Items = basket.Items.ToBasketItemViewModels(),
                Total = basket.GetTotal(basket.Items.ToList()),
                DiscountedTotal = basket.DiscountedTotal
            };
        }
        public static Discounts ToDiscountModel(this Models.Discounts discounts, Basket basket)
        {
            return new Discounts
            {
                DiscountList = discounts.DiscountList,
                DiscountTotal = basket.DiscountedTotal
            };
        }
    }
}
