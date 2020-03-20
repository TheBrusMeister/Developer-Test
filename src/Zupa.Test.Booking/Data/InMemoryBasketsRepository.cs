using System.Linq;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;
using Zupa.Test.Booking.ViewModels;

namespace Zupa.Test.Booking.Data
{
    internal class InMemoryBasketsRepository : IBasketsRepository
    {
        private Models.Basket _basket;

        public InMemoryBasketsRepository()
        {
            _basket = new Models.Basket();
        }

        public Task<Models.Basket> ReadAsync()
        {
            return Task.FromResult(_basket);
        }

        public Task ResetBasketAsync()
        {
            return Task.FromResult(_basket = new Models.Basket());
        }

        public Task<Models.Basket> AddToBasketAsync(Models.BasketItem item)
        {
            var items = _basket.Items.ToList();
            items.Add(item);
            _basket.Items = items;
            _basket.Total = _basket.GetTotal(items);

            return Task.FromResult(_basket);
        }

        public Task<Models.Basket> UpdateBasketTotals(ViewModels.Basket basket)
        {
            _basket.DiscountedTotal = basket.DiscountedTotal;
            _basket.Total = basket.Total;

            return Task.FromResult(_basket);
        }
    }
}
