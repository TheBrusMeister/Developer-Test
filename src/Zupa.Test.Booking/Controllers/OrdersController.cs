using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zupa.Test.Booking.ViewModels;

namespace Zupa.Test.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> PlaceOrder([FromBody]Basket basket)
        {
            var id = Guid.NewGuid();
            return CreatedAtAction(
                nameof(GetOrder),
                new { id },
                new Order { ID = id, GrossTotal = basket.Items.Sum(item => item.GrossPrice * item.Quantity) });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            return new Order { ID = id };
        }
    }
}