using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Interfaces;
using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Data
{
    public class CartRepository : ICartRepository
    {
        public CartRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ProductManagementDbContext DbContext { get; }

        public async Task<Cart> CreateAsync()
        {
            var cart = new Cart
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                LastChanged = DateTime.Now
            };
            await DbContext.Carts.AddAsync(cart);

            return cart;
        }

        public Task<Cart> GetAsync(Guid carKey)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> RemoveAsync(Guid carKey)
        {
            throw new NotImplementedException();
        }
    }
}
