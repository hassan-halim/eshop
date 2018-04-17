using SharedKernel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Core.Models
{
    public class Product : Entity<int>
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int VendorId{ get; set; }
        public Vendor Vendor { get; set; }
        public ICollection<ProductFeature> Features { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Product()
        {
            Features = new Collection<ProductFeature>();
        }
    }
}
