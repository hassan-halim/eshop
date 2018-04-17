using EshopApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopApi.Persistence
{
    public class EshopDbContext : IdentityDbContext<AppUser>
    {
        public EshopDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
