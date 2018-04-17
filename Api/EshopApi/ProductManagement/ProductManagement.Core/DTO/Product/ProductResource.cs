using SharedKernel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProductManagement.Core.DTO
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set;}
        public CategoryResource Category { get; set; }
        //public VendorResource Vendor { get; set; }
        public int VendorId { get; set; }
        public KeyValuePairResource<int> Vendor { get; set; }
        public ICollection<int> Features { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public ProductResource()
        {
            Features = new Collection<int>();
        }
    }
}
