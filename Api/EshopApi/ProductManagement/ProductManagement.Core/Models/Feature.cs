using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Core.Models
{
    public class Feature : Entity<int>
    {
        public string Name { get; set; }
    }
}
