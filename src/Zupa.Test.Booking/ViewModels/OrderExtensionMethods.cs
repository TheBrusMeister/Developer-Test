using System.Linq;

namespace Zupa.Test.Booking.ViewModels
{
    public static class OrderExtensionMethods
    {
        public static Order ToOrderViewModel(this Models.Order order)
        {
            return new Order
            {
                ID = order.ID,
                GrossTotal = order.GrossTotal,
                NetTotal = order.NetTotal,
                TaxTotal = order.TaxTotal,
                Items = order.Items.Select(item => item.ToOrderItemViewModel())
            };
        }
    }
}
