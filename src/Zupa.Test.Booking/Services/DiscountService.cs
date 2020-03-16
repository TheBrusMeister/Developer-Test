using System.Linq;
using Zupa.Test.Booking.Data;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountsRepository _discountRepository;
        private readonly IBasketsRepository _basketsRepository;

        public DiscountService(IDiscountsRepository discountsRepository, IBasketsRepository basketsRepository)
        {
            _discountRepository = discountsRepository;
            _basketsRepository = basketsRepository;
        }
        public void ApplyDiscount(ViewModels.Basket basket, DiscountItem discountItem)
        {
            string[] acceptableCodeNames = { "discount10", "discount50" };

            bool correctCode = acceptableCodeNames.Contains(discountItem.Code);

            if (!correctCode)
            {
                basket.FailureMessage = "Incorrect code";
                return;
            }

            if (basket.Total != 0)
            {
                var discountApplied =  _discountRepository.IsDiscountInRepository(discountItem.Code).Result;

                if(basket.DiscountedTotal != 0)
                {
                    basket.FailureMessage = "Multiple discounts cannot be applied.";
                    return;
                }

                if (!discountApplied)
                {
                    var subtractionMultiplier = discountItem.Amount / 100;
                    var subtractionAmount = basket.Total * subtractionMultiplier;

                    basket.DiscountedTotal = basket.Total - subtractionAmount;
                    _discountRepository.AddToDiscountRepositoryAsync(discountItem);
                    _basketsRepository.UpdateBasketTotals(basket);
                    basket.SuccessMessage = "Your " + discountItem.Amount + "% discount has been applied";
                    return;
                }

                basket.FailureMessage = "Invalid discount code.";
            }
        }
    }
}
