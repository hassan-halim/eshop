using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManagement.Core.DTO;
using ProductManagement.Core.Models;

namespace ProductManagement.Core
{
    public interface IProductManagmentRepository
    {
        Task<Product> GetProductAsync(int id, bool includeRelated = true);
        Task<Product> AddProductAsync(Product product);
        void RemoveProduct(Product product);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Vendor>> GetVendorsAsync();
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}