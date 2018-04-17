using SharedKernel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProductManagement.Core.DTO
{
    public class InputProductResource : KeyValuePairResource<int>
    {
        public int VendorId { get; set; }
        public int CategoryId { get; set; }
        public  ICollection<int> Features { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public InputProductResource()
        {
            Features = new Collection<int>();
        }
    }
}
