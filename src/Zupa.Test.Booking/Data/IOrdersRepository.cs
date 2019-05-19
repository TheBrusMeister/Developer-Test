using System;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    public interface IOrdersRepository
    {
        Task<Order> SaveAsync(Order order);
        Task<Order> ReadAsync(Guid id);
    }
}
