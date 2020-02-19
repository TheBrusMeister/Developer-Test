using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zupa.Test.Booking.Data;
using Zupa.Test.Booking.ViewModels;

namespace Zupa.Test.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketsRepository _basketsRepository;
        private readonly IDiscountsRepository _discountRepository;

        public BasketsController(IBasketsRepository basketsRepository, IDiscountsRepository discountsRepository)
        {
            _basketsRepository = basketsRepository;
            _discountRepository = discountsRepository;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Basket>> AddToBasket([FromBody]BasketItem basketItem)
        {
            var item = basketItem.ToBasketItemModel();
            var basket = await _basketsRepository.AddToBasketAsync(item);

            return basket.ToBasketViewModel();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Basket>> GetBasket()
        {
            var basket = await _basketsRepository.ReadAsync();
            return basket.ToBasketViewModel();
        }

        [HttpPut("/discount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Discounts>> ApplyDiscountToBasket([FromBody]Discount discountItem)
        {
            var item = discountItem.ToDiscountItem();

            string[] acceptableCodeNames = {"discount10", "discount50"};

            bool correctCode = discountItem.Code.Equals(acceptableCodeNames[0]) || discountItem.Code.Equals(acceptableCodeNames[1]);

            if (!correctCode)
            {
                Response.StatusCode = 400;
                return Content("the code can either be " + acceptableCodeNames[0] + " or " + acceptableCodeNames[1]);
            }

            if (correctCode)
            {
                var discountExists = await _discountRepository.IsDiscountInRepository(item.Code);

                if (discountExists)
                {
                    Response.StatusCode = 400;
                    return Content("A discount with the name " + item.Code + "  already exists");
                }

                if (!discountExists)
                {
                    var basket = await _basketsRepository.ReadAsync();
                    var basketModel = basket.ToBasketViewModel();

                    basketModel.ApplyDiscount(discountItem.Amount);
                    var discounts = await _discountRepository.AddToDiscountRepositoryAsync(discountItem);
                    return discounts.ToDiscountModel();
                }
            }

            Response.StatusCode = 400;
            return Content("something went wrong");
        }
    }
}