using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBLL.DTOs.Request
{
   public class AddProductRequest
    {
        public string? Name { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public string? PhotoPath { get; set; }
    }
}
