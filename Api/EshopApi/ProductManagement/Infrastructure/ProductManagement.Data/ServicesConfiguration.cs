using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductManagement.Core;
using ProductManagement.Core.Interfaces;

namespace ProductManagement.Data
{
    public static class ServicesConfiguration
    {
        public static void AddProductManagementServices
            (this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ProductManagementDbContext>
            (options => options.UseSqlServer(configuration.GetConnectionString("ProductManagement")));

            //add product management repositories
            services.AddScoped<IProductManagmentRepository, ProductManagmentRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
