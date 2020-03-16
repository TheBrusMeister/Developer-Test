using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    public class InMemoryDiscountsRepository : IDiscountsRepository
    {
        private Discounts _discounts;

        public InMemoryDiscountsRepository()
        {
            _discounts = new Discounts();
        }

        public Task<Discounts> AddToDiscountRepositoryAsync(DiscountItem discountItem)
        {
            var items = _discounts.DiscountList.ToList();
            items.Add(discountItem);
            _discounts.DiscountList = items;
            return Task.FromResult(_discounts);
        }

        public Task<Discounts> ReadAllAsync()
        {
            return Task.FromResult(_discounts);
        }

        public Task<DiscountItem> ReadAsync(string code)
        {
            return Task.FromResult(_discounts.DiscountList.First(discount => discount.Code.Equals(code)));
        }

        public Task<bool> IsDiscountInRepository(string code)
        {
            var items = _discounts.DiscountList.ToList();
            var hasItem = items.Any(x => x.Code.Equals(code));

            return Task.FromResult(hasItem);
        }

        public Task ResetDiscountsAsync()
        {
            return Task.FromResult(_discounts = new Discounts());
        }
    }
}
