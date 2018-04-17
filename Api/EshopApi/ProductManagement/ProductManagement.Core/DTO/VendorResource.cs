using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Core.DTO
{
    public class VendorResource : KeyValuePairResource<int>
    {
        public ContactResource Contact { get; set; }
    }
}
