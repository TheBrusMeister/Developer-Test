using System;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    public interface IProductsRepository
    {
        Task<Product[]> ReadAllAsync();
        Task<Product> ReadAsync(Guid id);
    }
}
