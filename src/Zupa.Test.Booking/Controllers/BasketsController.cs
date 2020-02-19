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

        public BasketsController(IBasketsRepository basketsRepository)
        {
            _basketsRepository = basketsRepository;
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

    }
}