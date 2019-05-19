using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    internal class InMemoryBasketsRepository : IBasketsRepository
    {
        private Basket _basket;

        public InMemoryBasketsRepository()
        {
            _basket = new Basket();
        }

        public Task<Basket> ReadAsync()
        {
            return Task.FromResult(_basket);
        }

        public Task ResetBasketAsync()
        {
            return Task.FromResult(_basket = new Basket());
        }

        public Task UpdateBasketAsync(Basket basket)
        {
            return Task.FromResult(_basket = basket);
        }
    }
}
