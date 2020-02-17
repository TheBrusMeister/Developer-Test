using System;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    public interface IDiscountsRepository
    {
        Task<Discounts> ReadAllAsync();
        Task<DiscountItem> ReadAsync(string code);
        Task ResetDiscountsAsync();
        Task<Discounts> AddToDiscountRepositoryAsync(DiscountItem discountItem);
        Task<bool> IsDiscountInRepository(string Code);
    }
}
