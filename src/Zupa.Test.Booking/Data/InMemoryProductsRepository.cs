using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    internal class InMemoryProductsRepository : IProductsRepository
    {
        private readonly List<Product> _products;

        public InMemoryProductsRepository()
        {
            _products = new List<Product> {
                new Product { ID = new Guid("52EE7B47-7313-4E17-B8DD-8255752AD3E3"), Name = "Pancake Stack", NetPrice = 5.592, TaxRate = 0.2, TaxValue = 1.398, GrossPrice = 6.99 },
                new Product { ID = new Guid("B3A0704E-0883-4B90-92F0-AADA88B774C4"), Name = "Syrup", NetPrice = 0.8, TaxRate = 0.2, TaxValue = 0.2, GrossPrice = 1.00 },
                new Product { ID = new Guid("B3A0704E-0883-4B90-92F0-AADA88B774C4"), Name = "Waffle", NetPrice = 3.192, TaxRate = 0.2, TaxValue = 0.798, GrossPrice = 3.99 },
                new Product { ID = new Guid("927F08A6-7579-4611-BFC4-0A54662083A5"), Name = "Scoop of Vanilla Ice Cream", NetPrice = 0.4, TaxRate = 0.2, TaxValue = 0.1, GrossPrice = 0.50 }
            };
        }

        public Task<Product[]> ReadAllAsync()
        {
            return Task.FromResult(_products.ToArray());
        }

        public Task<Product> ReadAsync(Guid id)
        {
            return Task.FromResult(_products.First(product => product.ID == id));
        }
    }
}
