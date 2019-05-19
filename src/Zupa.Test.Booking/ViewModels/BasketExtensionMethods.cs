using System;
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
                Items = basket.Items.ToOrderItemModels()
            };
        }
    }
}
