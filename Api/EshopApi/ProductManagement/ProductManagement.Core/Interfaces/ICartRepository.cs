using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> CreateAsync();
        Task<Cart> GetAsync(Guid carKey);
        Task<Guid> RemoveAsync(Guid carKey);

    }
}
