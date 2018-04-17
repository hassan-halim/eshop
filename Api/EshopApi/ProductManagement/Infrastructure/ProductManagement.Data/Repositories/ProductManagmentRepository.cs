using Microsoft.EntityFrameworkCore;
using ProductManagement.Core;
using ProductManagement.Core.DTO;
using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Data
{
    public class ProductManagmentRepository : IProductManagmentRepository
    {
        public ProductManagmentRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private ProductManagementDbContext DbContext { get; }

        public async Task<Product> AddProductAsync(Product product)
        {
            product.Created = DateTime.Now;
            product.LastChanged = DateTime.Now;

            await DbContext.Products.AddAsync(product);

            return product;
        }

        public void RemoveProduct(Product product)
        {
            DbContext.Remove(product);
        }

        public async Task<Product> GetProductAsync(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await DbContext.Products.FindAsync(id);

            var product = await DbContext.Products
               .Include(p => p.Features)
               .ThenInclude(pf => pf.Feature)
               .Include(p => p.Category)
               .Include(p => p.Vendor)
               .SingleOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var result = await DbContext.Categories.ToListAsync();
            
            return result; 
        }
        public async Task<IEnumerable<Vendor>> GetVendorsAsync()
        {
            var result = await DbContext.Vendors.ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var result = await DbContext.Products
                .Include(p=>p.Category)
                .Include(p=>p.Vendor)
                .ToListAsync();
            return result;
        }
    }
}
