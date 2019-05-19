using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    public interface IBasketsRepository
    {
        Task ResetBasketAsync();
        Task<Basket> ReadAsync();
        Task<Basket> AddToBasketAsync(BasketItem item);
    }
}
