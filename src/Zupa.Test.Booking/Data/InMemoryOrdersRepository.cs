using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    internal class InMemoryOrdersRepository : IOrdersRepository
    {
        private readonly List<Order> _orders;

        public InMemoryOrdersRepository()
        {
            _orders = new List<Order>();
        }

        public async Task<Order> ReadAsync(Guid id)
        {
            return _orders.First(order => order.ID == id);
        }

        public async Task<Order> SaveAsync(Order order)
        {
            _orders.Add(order);
            return order;
        }
    }
}
