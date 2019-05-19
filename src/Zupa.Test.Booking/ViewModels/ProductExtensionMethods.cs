namespace Zupa.Test.Booking.ViewModels
{
    public static class ProductExtensionMethods
    {
        public static Product ToProductViewModel(this Models.Product product)
        {
            return new Product
            {
                ID = product.ID,
                Name = product.Name,
                NetPrice = product.NetPrice,
                TaxRate = product.TaxRate,
                TaxValue = product.TaxValue,
                GrossPrice = product.GrossPrice
            };
        }
    }
}
