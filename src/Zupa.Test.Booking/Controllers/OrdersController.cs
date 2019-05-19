using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zupa.Test.Booking.Data;
using Zupa.Test.Booking.ViewModels;

namespace Zupa.Test.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBasketsRepository _basketsRepository;
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IBasketsRepository basketsRepository, IOrdersRepository ordersRepository)
        {
            _basketsRepository = basketsRepository;
            _ordersRepository = ordersRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> PlaceOrder([FromBody]Basket basket)
        {
            var orderModel = basket.ToOrderModel();
            await _ordersRepository.SaveAsync(orderModel);
            await _basketsRepository.ResetBasketAsync();

            return CreatedAtAction(
                nameof(GetOrder),
                new { orderModel.ID },
                orderModel.ToOrderViewModel());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _ordersRepository.ReadAsync(id);
            return order.ToOrderViewModel();
        }
    }
}