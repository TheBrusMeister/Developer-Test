namespace Zupa.Test.Booking.ViewModels
{
    public static class OrderItemExtensionMethods
    {
        public static OrderItem ToOrderItemViewModel(this Models.OrderItem orderItem)
        {
            return new OrderItem
            {
                Quantity = orderItem.Quantity,
                Id = orderItem.Id,
                GrossPrice = orderItem.GrossPrice,
                NetPrice = orderItem.NetPrice,
                TaxRate = orderItem.TaxRate,
                Name = orderItem.Name
            };
        }
    }
}
