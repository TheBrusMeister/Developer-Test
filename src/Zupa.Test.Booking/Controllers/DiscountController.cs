using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zupa.Test.Booking.Data;
using Zupa.Test.Booking.ViewModels;

namespace Zupa.Test.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountsRepository _discountRepository;
        private readonly IBasketsRepository _basketsRepository;

        public DiscountController(IDiscountsRepository discountsRepository, IBasketsRepository basketsRepository)
        {
            _discountRepository = discountsRepository;
            _basketsRepository = basketsRepository;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Discounts>> ApplyDiscount([FromBody]Discount discountItem)
        {
            //TODO: move this logic out of the controller into a service.
            var item = discountItem.ToDiscountItem();

            string[] acceptableCodeNames = { "discount10", "discount50" };

            bool correctCode = discountItem.Code.Equals(acceptableCodeNames[0]) || discountItem.Code.Equals(acceptableCodeNames[1]);

            if (!correctCode)
            {
                return BadRequest(new { message = "the code can either be " + acceptableCodeNames[0] + " or " + acceptableCodeNames[1] });
            }

            if (correctCode)
            {
                var discountExists = await _discountRepository.IsDiscountInRepository(item.Code);

                if (discountExists)
                {
                    return BadRequest(new { message = "A discount with the name " + item.Code + "  already exists" });
                }

                if (!discountExists)
                {
                    var basket = await _basketsRepository.ReadAsync();
                    var basketModel = basket.ToBasketViewModel();

                    basketModel.ApplyDiscount(discountItem.Amount);
                    var discounts = await _discountRepository.AddToDiscountRepositoryAsync(discountItem);
                    basket.DiscountedTotal = basketModel.DiscountedTotal;
                    await _basketsRepository.UpdateBasket(basket);

                    Response.StatusCode = 201;
                    return discounts.ToDiscountModel(basketModel);
                }
            }

            return BadRequest(new { message = "A discount with the name " + item.Code + "  already exists" });
        }
    }
}