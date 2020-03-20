using System.Threading.Tasks;
using Zupa.Test.Booking.ViewModels;

namespace Zupa.Test.Booking.Data
{
    public interface IBasketsRepository
    {
        Task ResetBasketAsync();
        Task<Models.Basket> ReadAsync();
        Task<Models.Basket> AddToBasketAsync(Models.BasketItem item);
        Task<Models.Basket> UpdateBasketTotals(Basket basket);
    }
}
