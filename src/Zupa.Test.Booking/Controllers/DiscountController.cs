using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zupa.Test.Booking.Data;
using Zupa.Test.Booking.Services;
using Zupa.Test.Booking.ViewModels;

namespace Zupa.Test.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountsRepository _discountRepository;
        private readonly IBasketsRepository _basketsRepository;
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountsRepository discountsRepository, IBasketsRepository basketsRepository, IDiscountService discountService)
        {
            _discountRepository = discountsRepository;
            _basketsRepository = basketsRepository;
            _discountService = discountService;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Basket>> ApplyDiscount([FromBody]Discount discountItem)
        {
            var basket = await _basketsRepository.ReadAsync();
            var basketModel = basket.ToBasketViewModel();
            _discountService.ApplyDiscount(basketModel, discountItem);

            if (basketModel.FailureMessage != null)
            {
                return BadRequest(new { message = basketModel.FailureMessage });
            }

            Response.StatusCode = 201;
            return basketModel;
        }
    }
}