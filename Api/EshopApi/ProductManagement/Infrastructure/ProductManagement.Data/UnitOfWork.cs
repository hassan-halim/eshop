using ProductManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductManagementDbContext dbContext;

        public UnitOfWork(ProductManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CompleteAsync()
        {
            await   dbContext.SaveChangesAsync();
        }
    }
}
