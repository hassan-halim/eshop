using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Core.Models
{
    public class ProductFeature
    {
        public int ProductId { get; set; }
        public int FeatureID { get; set; }
        public Product Product { get; set; }
        public Feature Feature { get; set; }
    }
}
