using SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManagement.Core.Models
{
    public class Vendor : Entity<int>
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public string Address { get; set; }
        [StringLength(100)]
        public string ContactEmail { get; set; }
    }
}
